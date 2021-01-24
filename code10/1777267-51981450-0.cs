    public static class Extensions
    {
        public static string ToStringSafe(this object value)
        {
            // return empty string
            if (value == null) {
                return String.Empty;
            }
 
            return value.ToString();
        }
    }
