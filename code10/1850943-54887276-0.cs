    static void Main(string[] args)
        {
            //ListFileInDirectory(@"C:\Users\albto\Documents\_projetos\MultiplesFiles\MultiplesFiles\_arquivos");
            ListFileInDirectory(@"C:\Users\liewm\Desktop\L907C524_1x");
            Console.WriteLine("Press enter to continue");
            Console.Read();
        }
        private static void ListFileInDirectory(string workingDirectory)
        {
            string[] filePaths = Directory.GetFiles(workingDirectory);
            List<string> allLines = new List<string>();
            foreach (string filePath in filePaths)
            {
                try
                {
                    //stores the files address
                    allLines.Add(filePath);
                    //stores file lines
                    allLines.AddRange(System.IO.File.ReadAllLines(filePath));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
            //shows all stored lines
            allLines.ForEach(Console.WriteLine);
            Console.ReadLine();
        }
