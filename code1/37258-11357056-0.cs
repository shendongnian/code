        void removeDuplicate()
        {
          string value1 = RemoveDuplicateChars("Devarajan");
        }
         static string RemoveDuplicateChars(string key)
        {
           
            string table = "";
            string result = "";          
            foreach (char value in key)
            {
                if (table.IndexOf(value) == -1)
                {
                    table += value;
                    result += value;
                }
            }
            return result;
        }
