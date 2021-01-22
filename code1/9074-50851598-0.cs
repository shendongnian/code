    public static class FileNameCorrector
    {
        private static HashSet<char> invalid = new HashSet<char>(Path.GetInvalidFileNameChars());
    
        public static string ToValidFileName(this string name, char replacement = '\0')
        {
            var builder = new StringBuilder();
            foreach (var cur in name)
            {
                if (cur > 31 && cur < 128 && !invalid.Contains(cur))
                {
                    builder.Append(cur);
                }
                else if (replacement != '\0')
                {
                    builder.Append(replacement);
                }
            }
    
            return builder.ToString();
        }
    }
    
