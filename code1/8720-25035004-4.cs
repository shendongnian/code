        public static string Keys(Dictionary<string, string> dictionary)
        {
            string value;
            int count = 0;
            foreach (var key in dictionary.Keys)
            {
                value = dictionary[key];
                count++;
            }
            return "Keys";
        }
