    public static class DecimalExtensions
    {
        /// <summary>
        ///     Converts a numeric value to its equivalent currency string representation using the specified culture-specific format information.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>The currency string representation of the value as specified by <paramref name="provider" />.</returns>
        public static string ToCurrency(this decimal value, IFormatProvider provider) =>
            /// Use "1" (or "-1" if value is negative)
            /// as a placeholder for the actual value.
            (value < 0 ? -1 : 1)
            /// Format as a currency using the "c" format specifier.
            .ToString("c0", provider)
            /// Convert the absolute value to its string representation
            /// then replace the placeholder "1".
            /// We used absolute value since the negative sign
            /// is already converted to its string representation
            /// using the "c" format specifier.
            .Replace("1", Math.Abs(value).ToString("#,0.############################", provider));
    }
