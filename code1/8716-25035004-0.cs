        public static string Normal(Dictionary<string, string> dictionary)
        {
            string value;
            int count = 0;
            foreach (var kvp in dictionary)
            {
                value = kvp.Value;
                count++;
            }
            return "Normal";
        }
