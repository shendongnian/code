    public static class StringBuilderExtensions
    {
        public static StringBuilderWrapper SetNewLineInitialCharacter(this StringBuilder builder, string prefix)
        {
            return new StringBuilderWrapper(builder, prefix);
        }
    }
