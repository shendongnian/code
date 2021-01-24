                bool run = true;
                while (run)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Path:");
                    string answer = Console.ReadLine();
    
                    if (Directory.Exists(answer)) run = false;
                    else
                    {
                        Console.WriteLine("Path Does not exists. Try again. Press enter to continue...");
                        Console.ReadLine();
                    }
                }
