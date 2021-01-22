    public static class IntegerExtensions
    {
        public static int ParseInt(this string value, int defaultValue = 0)
        {
            int parsedValue;
            int.TryParse(value, out parsedValue);
            return parsedValue;
        }
        public static int? ParseNullableInt(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return value.ParseInt();
        }
    }
