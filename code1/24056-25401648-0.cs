    using System;
    using System.Text;
    
    namespace KZ.SigDigTest
    {
        public static class SignificantDigits
        {
            public static String DecimalSeparator;
    
            static SignificantDigits()
            {
                System.Globalization.CultureInfo ci = System.Threading.Thread.CurrentThread.CurrentCulture;
                DecimalSeparator = ci.NumberFormat.NumberDecimalSeparator;
            }
    
            /// <summary>
            /// Format a double to a given number of significant digits.
            /// </summary>
            /// <example>
            /// 1239451.0 -> "1240000" (digits = 3)
            /// 5084611353.0 -> "5085000000" (digits = 4)
            /// 0.00000000000000000846113537656557 -> "0.00000000000000000846114" (digits = 6)
            /// 50.846 -> "50.85" (digits = 4)
            /// 990.0 -> "1000" (digits = 1)
            /// -5488.0 -> "-5000" (digits = 1)
            /// -990.0 -> "-1000" (digits = 1)
            /// 0.0000789 -> "0.000079" (digits = 2)
            /// </example>
            public static String Format(double number, int digits, Boolean showTrailingZeroes, Boolean alwaysShowDecimalSeparator)
            {
                String sSign = "";
                String sBefore = "0"; // Before the decimal separator
                String sAfter = ""; // After the decimal separator
    
                if (double.IsNaN(number) ||
                    double.IsInfinity(number))
                {
                    return number.ToString();
                }
    
                if (number != 0d)
                {
                    if (digits < 1)
                    {
                        throw new InvalidOperationException("The digits parameter must be greater than zero.");
                    }
    
                    if (number < 0d)
                    {
                        sSign = "-";
                        number = Math.Abs(number);
                    }
    
                    // Use scientific formatting as an intermediate step
                    String sFormatString = "{0:" + new String('#', digits) + "E0}";
                    String sScientific = String.Format(sFormatString, number);
    
                    String sSignificand = sScientific.Substring(0, digits);
                    int exponent = int.Parse(sScientific.Substring(digits + 1));
                    // (the significand now already contains the requested number of digits with no decimal separator in it)
    
                    StringBuilder sFractionalBreakup = new StringBuilder(sSignificand);
    
                    if (!showTrailingZeroes)
                    {
                        while (sFractionalBreakup[sFractionalBreakup.Length - 1] == '0')
                        {
                            sFractionalBreakup.Length--;
                            exponent++;
                        }
                    }
    
                    // Place decimal separator (insert zeroes if necessary)
    
                    int separatorPosition = 0;
    
                    if ((sFractionalBreakup.Length + exponent) < 1)
                    {
                        sFractionalBreakup.Insert(0, "0", 1 - sFractionalBreakup.Length - exponent);
                        separatorPosition = 1;
                    }
                    else if (exponent > 0)
                    {
                        sFractionalBreakup.Append('0', exponent);
                        separatorPosition = sFractionalBreakup.Length;
                    }
                    else
                    {
                        separatorPosition = sFractionalBreakup.Length + exponent;
                    }
    
                    sBefore = sFractionalBreakup.ToString();
    
                    if (separatorPosition < sBefore.Length)
                    {
                        sAfter = sBefore.Substring(separatorPosition);
                        sBefore = sBefore.Remove(separatorPosition);
                    }
                }
    
                String sReturnValue = sSign + sBefore;
    
                if (sAfter == "")
                {
                    if (alwaysShowDecimalSeparator)
                    {
                        sReturnValue += DecimalSeparator + "0";
                    }
                }
                else
                {
                    sReturnValue += DecimalSeparator + sAfter;
                }
    
                return sReturnValue;
            }
        }
    }
