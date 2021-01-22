    public static class EnumUtils
    {
        public static Nullable<T> Parse<T>(string input) where T : struct
        {
            //since we cant do a generic type constraint
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Generic Type 'T' must be an Enum");
            }
            if (!string.IsNullOrEmpty(input))
            {
                if (Enum.GetNames(typeof(T)).Any(
                      e => e.Trim().ToUpperInvariant() == input.Trim().ToUpperInvariant()))
                {
                    return (T)Enum.Parse(typeof(T), input, true);
                }
            }
            return null;
        }
    }
