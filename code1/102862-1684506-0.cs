    public static class StringExtensions
    {
        public static string FormatEx(this string s, params string[] parameters)
        {
            Regex r = new Regex(@"\{\*\}", RegexOptions.IgnoreCase);
            for (int i = 0; i < parameters.Length; i++)
            {
                s = r.Replace(s, parameters[i], 1);
            }
            return s;
        }
    }
