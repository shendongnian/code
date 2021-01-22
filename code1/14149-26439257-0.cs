    static class ExtentionMethodCollection
    {
        public static string Inverse(this string BASE)
        {
            return new string(BASE.Reverse().ToArray());
        }
    }
