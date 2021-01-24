    public static class StringExtensions
    {
        public static string Reverse(this string toReverse)
        {
            var stringArray = toReverse.ToCharArray();
            Array.Reverse(stringArray);
            return new string(stringArray);
        }
    }
