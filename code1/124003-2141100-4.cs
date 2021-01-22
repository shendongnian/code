        public static decimal FormatDecimal(decimal i)
        {
            List<decimal> myFactors = new List<decimal>()
            { 1000m * 1000m, 1000m};
            foreach (decimal conversionFactor in myFactors)
            {
                decimal result = decimal.Round(i / conversionFactor, 4);
                if (result * conversionFactor == i)
                {
                    return result;
                }
            }
            return i;
        }
