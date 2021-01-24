        public static string GetServerNameForUser(string value)
        {
            // this part will wrap input with " e.g. "value"
            value = "\"" + value + "\"";
            string[] data = File.ReadAllLines("C:\\test\\TestFile.txt");
            foreach(string log in data)
            {
                string[] temp = log.Split(',');
                if(temp[0].Equals(value))
                {
                    return temp[1];
                }
            }
            return "Not Found";
        }
