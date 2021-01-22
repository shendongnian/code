    public static class DecimalExtensions
    {
        public static string ToCurrency(this decimal decimalValue)
        {
            return $"{decimalValue:C}";
        }
    }
