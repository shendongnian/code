            static void openForm()
            {
                Console.WriteLine("Form opened!");
            }
    
            static void doSomething()
            {
                Console.WriteLine("Do something!");
            }
    
            static void Main(string[] args)
            {
                bool optionForm = false;
                int seconds = 1;
    
                Console.Write("Press 'k' to open form");
                
                while (true)
                {                
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo c = Console.ReadKey(true);
                        if (c.Key == ConsoleKey.K)
                        {                        
                            optionForm = true;
                            break;
                        }
                    }
                    
                    System.Threading.Thread.Sleep(1000);
    
                    if (seconds++ > 10)
                        break;
    
                    Console.Write('.');
                }
    
                Console.WriteLine();
    
                if (optionForm)
                    openForm();
                else
                    doSomething();
    
                Console.ReadKey();
            }
        
