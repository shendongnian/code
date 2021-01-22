        void removeDuplicate()
        {
          string value1 = RemoveDuplicateChars("Devarajan");
        }
         static string RemoveDuplicateChars(string key)
        {
            string result = "";          
            foreach (char value in key)
                if (result.IndexOf(value) == -1)                   
                    result += value;
            return result;
        }
