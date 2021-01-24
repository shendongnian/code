    using System;
    using MoreLinq;
    namespace MattConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter a message");
                var userMessage = Console.ReadLine();
    
                if (userMessage?.Length <= 210)
                {
                    var batchedData = userMessage.Batch(70);
    
                    foreach (var entry in batchedData)
                    {
                        Console.WriteLine("");
                        var asString = string.Concat(entry);
                        Console.WriteLine(asString);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid, please enter a message lower than 210 characters.");
                }
    
                Console.ReadKey();
            }
        }
    }
