    static class ExtentionMethodCollection
    {
        public static string Inverse(this string @base)
        {
            return new string(@base.Reverse().ToArray());
        }
    }
