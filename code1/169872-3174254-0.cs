    public static class StringExtensions
    {
        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value)
                        ? true
                        : ReferenceEquals(value, null)
                                ? true
                                : string.IsNullOrEmpty(value.Trim(' '))
                                    ? true
                                    : false;
        }
    }
