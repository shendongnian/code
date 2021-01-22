    public static class Int32Extensions
    {
        public static string ToOrdinal(this int i)
        {
            return (i + "th")
                .Replace("1th", "1st")
                .Replace("2th", "2nd")
                .Replace("3th", "3rd");
        }
    }
