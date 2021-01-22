    public static class StringExtensions
          {
            public static string RemoveUnnecessary(this string source)
            {
                string result = string.Empty;
                string regex = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
                Regex reg = new Regex(string.Format("[{0}]", Regex.Escape(regex)));
                result = reg.Replace(source, "");
                return result;
            }
        }
