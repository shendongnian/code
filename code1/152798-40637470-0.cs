        public static string TruncateMiddle(string source)
        {
            if (String.IsNullOrWhiteSpace(source) || source.Length < 260) 
                return source;
            return string.Format("{0}...{1}", 
                source.Substring(0, 235),
                source.Substring(source.Length - 20));
        }
