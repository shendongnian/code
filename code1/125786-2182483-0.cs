    public static class StringExtensions
    {
        public static string Join(this List<string> values, char separator)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < values.Count; i++)
            {
                string value = values[i];
                stringBuilder.Append(value);
                
                if (i < (values.Count - 1))
                {
                    stringBuilder.Append(separator);
                }
            }
            
            return stringBuilder.ToString();
        }
    }
