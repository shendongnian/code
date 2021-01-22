        public static string TruncateAtWord(this string value, int maxLength)
        {
            if (value == null || value.Trim().Length <= maxLength)
                return value;
            string ellipse = "...";
            char[] truncateChars = new char[] { ' ', ',' };
            int index = value.Trim().LastIndexOfAny(truncateChars);
            
            while ((index + ellipse.Length) > maxLength)
                index = value.Substring(0, index).Trim().LastIndexOfAny(truncateChars);
            if (index > 0)
                return value.Substring(0, index) + ellipse;
            return value.Substring(0, maxLength - ellipse.Length) + ellipse;
        }
