    public static class StringExtensions
    {
        public static String EmptyIfNull(this String instance)
        {
            return instance ?? String.Empty;
        }
    }
