        public static T RoundOff<T>(this T rawNumber, T roundToNearest)
            where T : IComparable<T>
        {
            if (typeof(T).IsNumericType())
            {
                decimal decimalRoundToNearest   = Convert.ToDecimal(roundToNearest);
                decimal rawMultiples            = Convert.ToDecimal(rawNumber) / Convert.ToDecimal(roundToNearest);
                decimal decimalRoundedMultiples = Math.Round(rawMultiples);
                decimal decimalRoundedNumber    = decimalRoundedMultiples * decimalRoundToNearest;
                return (T)Convert.ChangeType(decimalRoundedNumber, typeof(T));
                // alternative
                // TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                // return (T)converter.ConvertFrom(decimalRoundedNumber);
            }
            else
            {
                throw new Exception("Type " + typeof(T) + " is not numeric");
            }
        }
