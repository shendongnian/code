    public static string SelectFile(string path)
            {
                bool FileSelect = false;
                int FileChoice = 0;
                List<string> Files = new List<string>();
    
                foreach (string file in System.IO.Directory.GetFiles("."))
                {
                    Files.Add(file);
                }
                if (Files.Count > 0)
                {
                    FileSelect = true;
                }
                else
                {
                    return "";
                }
                while (FileSelect)
                {
                    Console.Clear();
                    Console.WriteLine("Select a file");
                    for (int i = 0; i < Files.Count; i++)
                    {
                        if (i == FileChoice)
                        {
                            Console.Write("[*]");
                        }
                        else
                        {
                            Console.Write("[ ]");
                        }
                        Console.WriteLine(Files[i]);
                    }
                    var key = Console.ReadKey();
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        FileChoice -= 1;
                        if (FileChoice == -1)
                        {
                            FileChoice = Files.Count - 1;
                        }
                    }
                    if (key.Key == ConsoleKey.DownArrow)
                    {
                        FileChoice += 1;
                        if (FileChoice == Files.Count)
                        {
                            FileChoice = 0;
                        }
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        FileSelect = false;
                    }
                }
                return Files[FileChoice];
            }
