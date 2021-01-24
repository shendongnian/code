    namespace Stackoverflow
    {
        using System;
        class Program
        {
            public static void Main(string[] args)
            {    
                ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
                string typed = string.Empty;
    
                // loop while condition is true
                while (true)
                {
                    // read input character-wise
                    while (keyInfo.Key != ConsoleKey.Enter)
                    {
                        keyInfo = Console.ReadKey();
                                            
                        // check for close-combination
                        if (keyInfo.Key == ConsoleKey.F1 && (keyInfo.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            Environment.Exit(0);
                        }
    
                        // add up input-string
                        typed += keyInfo.KeyChar;
                    }
    
                    // user pressed enter, do something with the input
                    try
                    {
                        if (typed == "com")
                        {
                            // right option - do something
                        }
                        else
                        {
                            // wrong option - reset ConsoleKeyInfo + input
                            Console.WriteLine("\n" + typed + " isn't an option.");
                            keyInfo = new ConsoleKeyInfo();
                            typed = string.Empty;
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                        // handle exceptions
                    }
                }
            }
        }
    }
