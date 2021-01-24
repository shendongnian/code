    try
    {
        int number = 0;
        string[] files = Directory.GetFiles("C:\\", "*.*",
            SearchOption.TopDirectoryOnly);
        foreach (string file in files)
        {
            try
                {
                    string[] innerFiles = Directory.GetFiles(file, "*.*",
                        SearchOption.TopDirectoryOnly);
                }
                catch (Exception e)
                {
                    // stuff here
                }
                number = number + 1;
                Console.ForegroundColor = ConsoleColor.Green;
                DateTime now = DateTime.Now;
                    Console.Write("[" + now + "]");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(" [" + number + "] ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(file + "\n");
                }
                Console.WriteLine("");
                Console.WriteLine("- " + number + " files found!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("- An unknown error occoured and the contents " +
                    "of this folder can not be displayed.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadKey();
        }
