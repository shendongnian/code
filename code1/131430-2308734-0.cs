    public static class OriginalTextExtensions
    {
        public static string OriginalText1SafeString(this OriginalText original)
        {
            return original == null ? string.Empty : original.OriginalText1;
        } 
    }
