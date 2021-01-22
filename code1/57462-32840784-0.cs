    public static class Extensions
    {
        /// <summary>
        /// Returns true if string is numeric and not empty or null or whitespace.
        /// Determines if string is numeric by parsing as Double
        /// </summary>
        /// <param name="str"></param>
        /// <param name="style">Optional style - defaults to NumberStyles.Number (leading and trailing whitespace, leading and trailing sign, decimal point and thousands separator) </param>
        /// <param name="culture">Optional CultureInfo - defaults to InvariantCulture</param>
        /// <returns></returns>
        public static bool IsNumeric(this string str, NumberStyles style = NumberStyles.Number,
            CultureInfo culture = null)
        {
            double num;
            if (culture == null) culture = CultureInfo.InvariantCulture;
            return Double.TryParse(str, style, culture, out num) && !String.IsNullOrWhiteSpace(str);
        }
    }
