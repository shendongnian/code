        public static bool init_access(string file_path)
        {
            if (File.Exists(file_path))
            {
                int counter = 0;
                foreach (string line in File.ReadAllLines(file_path).ToList())
                {
                    counter++;
                    Console.WriteLine(counter + " " + line);
                }
    
                return true;
            }
    
            return false;
        }
