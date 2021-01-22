    static class MathCustom
    {
        static public byte NumberOfDecimals(decimal value)
        {
            sbyte places = -1;
            decimal testValue;
            do
            {
                places++;
                testValue = Math.Round(value, places);
            } while (testValue != value);
            return (byte)places;
        }
        static public byte NumberOfDecimals(float value)
        {
            sbyte places = -1;
            float testValue;
            do
            {
                places++;
                testValue = (float)Math.Round((decimal)value, places);
            } while (testValue != value);
            return (byte)places;
        }
        /// <summary>
        /// This version of NumberOfDecimals allows you to provide a Maximum
        /// for allowable decimals. This method will allow for the correction
        /// of floating point errors when it is less than 10 or passed in as null.
        /// </summary>
        /// <param name="value">Value to check the number of held decimal places</param>
        /// <param name="knownMaximum"></param>
        /// <returns>The number of decimal places in Value.</returns>
        static public byte NumberOfDecimals(decimal value, byte? knownMaximum)
        {
            byte maximum;
            decimal localValue;
            sbyte places = -1;
            decimal testValue;
            if (knownMaximum == null)
            {
                maximum = 9;
            }
            else
            {
                maximum = (byte)knownMaximum;
            }
            localValue = Math.Round(value, maximum);
            do
            {
                places++;
                testValue = Math.Round(localValue, places);
            } while (testValue != localValue);
            return (byte)places;
        }
    }
