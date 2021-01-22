    public static class GuidExtensions
        {
            public static bool IsGuid(this string value)
            {
                Guid output;
                return Guid.TryParse(value, out output);
            }
        }
