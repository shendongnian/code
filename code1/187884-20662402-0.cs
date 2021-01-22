        public static string Truncate(string input, int truncLength)
        {
            return (!String.IsNullOrEmpty(input) && input.Length >= truncLength)
                       ? input.Substring(0, truncLength)
                       : input;
        }
