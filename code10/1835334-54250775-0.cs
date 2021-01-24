    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                ProcessNumbers();
            }
    
            private static void ProcessNumbers()
            {
                var myList = new List<int>();
                string sinput = String.Empty;
                var number = 0;
                do
                {
                    try
                    {
                        Console.Write("Write the number you would like to add to your list (type stop when you are done): ");
                        var input = Console.ReadLine();
    
                        if(input != "stop")
                        {
                            number = int.Parse(input);
                            myList.Add(number);
                        }
                        else
                        {
                            sinput = input;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("ERROR: You typed a letter instead of a number, try again!");
                    }
    
                } while (sinput != "stop");
    
                var sum = myList.Sum();
                Console.WriteLine("The sum of all your numbers is: " + sum);
                Console.Write("Press any key to exist...");
                Console.ReadKey();
            }
        }
    }
