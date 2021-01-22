        public static string[] SplitAndTrim(this string text, char separator)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }
            return text.Split(separator).Select(t => t.Trim()).ToArray();
        }
