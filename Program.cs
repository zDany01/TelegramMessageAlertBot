using System;
using Telegram.Bot;
using Telegram.Bot.Exceptions;

namespace TelegramMessageAlertBot
{
    internal class Program
    {
        private static void WriteWithColor<T>(T value, ConsoleColor color, bool endLine = false)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (endLine) Console.WriteLine(value);
            else Console.Write(value);
            Console.ForegroundColor = originalColor;
        }

        private static bool CheckToken(string botToken)
        {
            try
            {
                _ = new TelegramBotClient(botToken).GetMeAsync().Result;
                return true;
            }
            catch (AggregateException ex)
            {
                foreach (Exception innerExceptions in ex.InnerExceptions) if (innerExceptions is ApiRequestException) return false;
                throw ex;
            }
        }

        private static void Main(string[] args)
        {
            int result;
            do
            {
                Console.Clear();
                Console.Write("App Menu\n1. Start ChatID Reply\n2. Send a message to a user\n3. Send a message to multiple users\n4. Save Token\n5. Load another token\n\nChoose: ");
                if (!int.TryParse(Console.ReadLine(), out result)) result = -1;
                switch (result)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        throw new NotImplementedException();
                    default: result = -1; break;
                }
            } while (result == -1);

            Console.ReadKey();
        }
    }
}
