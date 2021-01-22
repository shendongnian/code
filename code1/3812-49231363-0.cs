    public static int ParseInt(this string value, int defaultIntValue = 0)
            {
                return int.TryParse(value, out var parsedInt) ? parsedInt : defaultIntValue;
            }
    public static int? ParseNullableInt(this string value)
            {
                if (string.IsNullOrEmpty(value))
                    return null;
    
                return value.ParseInt();
            }
