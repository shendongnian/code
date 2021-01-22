    using System;
    using System.Text;
    
    namespace ConsoleApplicationRound
    {
        class Maths
        {
            /// <summary>
            ///     The word "Window"
            /// </summary>
            private static String m_strZeros = "000000000000000000000000000000000";
            /// <summary>
            ///     The minus sign
            /// </summary>
            public const char m_cDASH = '-';
    
            /// <summary>
            ///     Determines the number of digits before the decimal point
            /// </summary>
            /// <param name="cDecimal">
            ///     Language-specific decimal separator
            /// </param>
            /// <param name="strValue">
            ///     Value to be scrutinised
            /// </param>
            /// <returns>
            ///     Nr. of digits before the decimal point
            /// </returns>
            private static ushort NrOfDigitsBeforeDecimal(char cDecimal, String strValue)
            {
                short sDecimalPosition = (short)strValue.IndexOf(cDecimal);
                ushort usSignificantDigits = 0;
    
                if (sDecimalPosition >= 0)
                {
                    strValue = strValue.Substring(0, sDecimalPosition + 1);
                }
    
                for (ushort us = 0; us < strValue.Length; us++)
                {
                    if (strValue[us] != m_cDASH) usSignificantDigits++;
    
                    if (strValue[us] == cDecimal)
                    {
                        usSignificantDigits--;
                        break;
                    }
                }
    
                return usSignificantDigits;
            }
    
            /// <summary>
            ///     Rounds to a fixed number of significant digits
            /// </summary>
            /// <param name="d">
            ///     Number to be rounded
            /// </param>
            /// <param name="usSignificants">
            ///     Requested significant digits
            /// </param>
            /// <returns>
            ///     The rounded number
            /// </returns>
            public static String Round(char cDecimal,
                double d,
                ushort usSignificants)
            {
                StringBuilder value = new StringBuilder(Convert.ToString(d));
    
                short sDecimalPosition = (short)value.ToString().IndexOf(cDecimal);
                ushort usAfterDecimal = 0;
                ushort usDigitsBeforeDecimalPoint =
                    NrOfDigitsBeforeDecimal(cDecimal, value.ToString());
    
                if (usDigitsBeforeDecimalPoint == 1)
                {
                    usAfterDecimal = (d == 0)
                        ? usSignificants
                        : (ushort)(value.Length - sDecimalPosition - 2);
                }
                else
                {
                    if (usSignificants >= usDigitsBeforeDecimalPoint)
                    {
                        usAfterDecimal =
                            (ushort)(usSignificants - usDigitsBeforeDecimalPoint);
                    }
                    else
                    {
                        double dPower = Math.Pow(10,
                            usDigitsBeforeDecimalPoint - usSignificants);
    
                        d = dPower*(long)(d/dPower);
                    }
                }
    
                double dRounded = Math.Round(d, usAfterDecimal);
                StringBuilder result = new StringBuilder();
    
                result.Append(dRounded);
                ushort usDigits = (ushort)result.ToString().Replace(
                    Convert.ToString(cDecimal), "").Replace(
                    Convert.ToString(m_cDASH), "").Length;
                // Add lagging zeros, if necessary:
                if (usDigits < usSignificants)
                {
                    if (usAfterDecimal != 0)
                    {
                        if (result.ToString().IndexOf(cDecimal) == -1)
                        {
                            result.Append(cDecimal);
                        }
                        result.Append(m_strZeros.Substring(0, usAfterDecimal +
                            Math.Min(0, usDigits - usSignificants)));
                    }
                }
    
                return result.ToString();
            }
        }
    }
