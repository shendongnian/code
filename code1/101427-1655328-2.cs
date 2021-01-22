    public static class SafeConvert
    {
        public static decimal? ToDecimal(string value)
        {
            decimal d;
            if (!Decimal.TryParse(value, out d))
                return null;
            return d;
        }
    }
