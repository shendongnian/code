        // Reads a CSV file and prints it out line by line
        public static void ReadAndPrintCSV(string fullyQualifiedPath)
        {
            using (System.IO.StreamReader sr = File.OpenText(fullyQualifiedPath))
            {
                string[] lineArray = null;
                while ((sr.Peek() > -1) && (lineArray = sr.ReadLine().Split(',')) != null)
                {
                    foreach (string str in lineArray)
                    {
                        Console.Write(str + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
