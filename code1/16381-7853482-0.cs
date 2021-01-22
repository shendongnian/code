    public static class Extensions
    {
        public static string ToDigitsOnly(this string input)
        {
            Regex digitsOnly = new Regex(@"[^\d]");
            return digitsOnly.Replace(input, "");
        }
    }
