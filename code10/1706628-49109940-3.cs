        public static string GetServerNameForUser(string value)
        {
            string[] data = File.ReadAllLines("C:\\test\\TestFile.txt");
            foreach(string log in data)
            {
                string[] temp = log.Split(',');
                if(temp[0].Contains(value))
                {
                    return temp[1];
                }
            }
            return "Not Found";
        }
