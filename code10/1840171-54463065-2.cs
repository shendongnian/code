        public static bool init_access(string file_path)
        {
            if (File.Exists(file_path))
            {
                int counter = 0;
                file_path = @"C:\Users\waqas\Desktop\TextFile.txt";
                foreach (string line in File.ReadAllLines(file_path).ToList())
                {
                    counter++;
                    Console.WriteLine(counter + " " + line);
                }
    
                return (true);
            }
    
            return false;
        }
