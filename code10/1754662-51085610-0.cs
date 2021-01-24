    class Program
    {
        static void Main(string[] args)
        {
            string str = "\"\"\"";
            str = TrimValueFromString("\"", str);
        }
        private static string TrimValueFromString(string value, string original)
        {
            string trimmed = original;
            if(original.IndexOf(value) == 0)
            {
                trimmed = original.Substring(value.Length);
            }
            if(trimmed.LastIndexOf(value) == (trimmed.Length - value.Length))
            {
                trimmed = trimmed.Substring(0, trimmed.LastIndexOf(value));
            }
            return trimmed;
        }
    }
