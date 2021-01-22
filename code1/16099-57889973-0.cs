    public static class DecimalExtensions
    {
        public static decimal WithTwoDecimalPoints(this decimal val)
        {
            return decimal.Parse(val.ToString("0.00"));
        }
    }
