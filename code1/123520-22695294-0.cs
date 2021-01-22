    public static class ExtendedMethods
    {
        public static string NbspToSpaces(this string text)
        {
            return text.Replace(Convert.ToChar(160), ' ');
        }
    }
