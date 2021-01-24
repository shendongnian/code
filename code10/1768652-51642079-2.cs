    namespace Stackoverflow
    {
        using System;
    
        class Program
        {
            public static void Main(string[] args)
            {    
                ConsoleKeyInfo keyInfo = default(ConsoleKeyInfo); 
                string input = string.Empty;
    
                // loop while condition is true
                while (true)
                {
                    // read input character-wise as long as user presses 'Enter' or 'Alt+F1'
                    while (true)
                    {
                        // read a single character and print it to console
                        keyInfo = Console.ReadKey(false);
    
                        // check for close-combination
                        if (keyInfo.Key == ConsoleKey.F1 && (keyInfo.Modifiers & ConsoleModifiers.Alt) != 0)
                        {
                            // program terminates
                            Environment.Exit(0);
                        }
    
                        // check for enter-press
                        if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            // break out of the loop without adding '\r' to the input string
                            break;
                        }
    
                        // add up input-string
                        input += keyInfo.KeyChar;
                    }
    
                    // optional: enter was pressed - add a new line
                    Console.WriteLine();
    
                    // user pressed enter, do something with the input
                    try
                    {
                        if (input == "com")
                        {
                            // right option - do something
                        }
                        else
                        {
                            // wrong option - reset ConsoleKeyInfo + input
                            Console.WriteLine("\n" + input + " isn't an option.");
                            keyInfo = default(ConsoleKeyInfo);
                            input = string.Empty;
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
