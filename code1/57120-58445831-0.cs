                    int num = 1;
                    var spin = new ConsoleSpinner();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("");
                    while (true)
                    {
                        spin.Turn();
                        Console.Write("\r{0} Generating Files ", num);
                        num++;
                    }
