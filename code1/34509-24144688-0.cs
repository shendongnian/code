    public static class StringExtension
    {    
        /// <summary> Returns the number of occurences of a string within a string, optional comparison allows case and culture control. </summary>
        public static int Occurrences(this System.String input, string value, StringComparison stringComparisonType = StringComparison.Ordinal)
        {
            if (String.IsNullOrEmpty(value)) return 0;
    
            int count    = 0;
            int position = 0;
    
            while ((position = input.IndexOf(value, position, stringComparisonType)) != -1)
            {
                position += value.Length;
                count    += 1;
            }
    
            return count;
        }
    
        /// <summary> Returns the number of occurences of a single character within a string. </summary>
        public static int Occurrences(this System.String input, char value)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++) if (input[i] == value) count += 1;
            return count;
        }
    }
