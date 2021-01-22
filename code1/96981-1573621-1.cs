    public static class DateTimeExtensionMethods
    {
        public static string ToString(this DateTime? date, string format)
        {
            if (date == null)
                return string.Empty;
    
            return date.Value.ToString(format);
        }
    }
