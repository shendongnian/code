    static class Extensions
    {
        public static string Quote(this string text)
        {
            return SurroundWith(text, "\"");
        }
        public static string SurroundWith(this string text, string surrounds)
        {
            return surrounds + text + surrounds;
        }
    }
