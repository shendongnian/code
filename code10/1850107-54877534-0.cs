    [AttributeUsage(AttributeTargets.Property)]
    public class CurrencyScrubberAttribute : Attribute, IScrubberAttribute
    {
        private static NumberStyles _currencyStyle = NumberStyles.Currency;
        private CultureInfo _culture = new CultureInfo("en-US");
        public object Scrub(string modelValue, out bool success)
        {
            var modelDecimal = 0M;
            success = decimal.TryParse(
                modelValue,
                _currencyStyle,
                _culture,
                out modelDecimal
            );
            return modelDecimal;
        }
    }
