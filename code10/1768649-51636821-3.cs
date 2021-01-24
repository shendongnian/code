            static void Main(string[] args)
            {
                Console.TreatControlCAsInput = true;
                var typed = ReadLine();
                if (typed == "com")
                {
                    Console.WriteLine("com");
                    //things happen here
                }
                //other else if's happen here
                else
                {
                    Console.WriteLine("\n" + typed + " isn't an option.");
                    
                }
    
    
            }
            public static string ReadLine() {
                StringBuilder sb = new StringBuilder();
                do
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if ((key.Modifiers & ConsoleModifiers.Alt) != 0)
                    {
                        if (key.Key == ConsoleKey.K)
                        {
                            Console.WriteLine("killing console");
                            System.Environment.Exit(0);
    
                        }
                    }
                    else
                    {
                        sb.Append(key.KeyChar);
                        if (key.KeyChar == '\n'||key.Key==ConsoleKey.Enter)
                        {
                            return sb.ToString();
                        }
                    }
                } while (true);
        
            }
