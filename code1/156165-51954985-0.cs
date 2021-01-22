    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ZonedDecimal
    {
        public static class ZonedDecimalConverter
        {
            public enum RoundingOperation { AwayFromZero, ToEven, Truncate };
    
            const byte MASK_UNSIGNED = 0xF0;
            const byte MASK_POSITIVE = 0xC0;
            const byte MASK_NEGATIVE = 0xD0;
    
            // this is a subset of the IBM code page 37 EBCDIC character set. we are only concerned with the characters that correspond to numbers.
            // for this dictionary, you key in with the code and get the character
            static readonly Dictionary<byte, char> m_IBM037Characters = new Dictionary<byte, char>()
            {   
                {0xC0, '{'},{0xC1, 'A'},{0xC2, 'B'},{0xC3, 'C'},{0xC4, 'D'},{0xC5, 'E'},{0xC6, 'F'},{0xC7, 'G'},{0xC8, 'H'},{0xC9, 'I'}
                ,{0xD0, '}'},{0xD1, 'J'},{0xD2, 'K'},{0xD3, 'L'},{0xD4, 'M'},{0xD5, 'N'},{0xD6, 'O'},{0xD7, 'P'},{0xD8, 'Q'},{0xD9, 'R'}
                ,{0xF0, '0'},{0xF1, '1'},{0xF2, '2'},{0xF3, '3'},{0xF4, '4'},{0xF5, '5'},{0xF6, '6'},{0xF7, '7'},{0xF8, '8'},{0xF9, '9'}
            };
    
            // this is the inverse of the dictionary above. you key in with the character and get the code
            static readonly Dictionary<char, byte> m_IBM037Codes = m_IBM037Characters.ToDictionary((pair) => pair.Value, (pair) => pair.Key);
    
            /// <summary>
            /// Returns a string that represents the zone-decimal version of the value specified
            /// </summary>
            /// <param name="value">The value</param>
            /// <param name="digitsLeft">How many fixed digits should be to the left of the decimal place</param>
            /// <param name="digitsRight">How many fixed digits should be to the right of the decimal place</param>
            /// <param name="roundingOperation">Indicates how to handle decimal digits beyond those specified by digitsRight</param>
            /// <returns></returns>
            public static string GetZonedDecimal(decimal value, int digitsLeft, int digitsRight, RoundingOperation roundingOperation)
            {
                // bounds checking
                if (digitsLeft < 1) throw new ArgumentException("Value must be greater than zero.", "digitsLeft");
                if (digitsRight < 0) throw new ArgumentException("Value must be greater than or equal to zero.", "digitsRight");
    
                // zoned-decimal has its own way of signaling negative
                bool isNegative = false;
                if (value < 0)
                {
                    isNegative = true;
                    value = -value; // same result as Math.Abs
                }
    
                // apply any rounding operation
                if (roundingOperation != RoundingOperation.Truncate)
                    value = Math.Round(value, digitsRight, roundingOperation == RoundingOperation.AwayFromZero ? MidpointRounding.AwayFromZero : MidpointRounding.ToEven);
    
    
                /*   calculating with decimal is extremely slow comapred to int. we'll multiple the number by digitsRight to put all significant
                 *   digits into whole number places and then load it into an unsigned long. since ulong.MaxValue is 18446744073709551615,
                 *   this gives us 20 digits total to work with. assuming you used 4 digits to the right, you could have up to 16 to the left, etc.
                 *   we do not use uint here since uint.MaxValue is 4294967295 and that would only give us 10 digits to work with. many fields
                 *   that i have seen have a COBOL signature of S9(11)V99, which is 13 digits total. also, we use unsigned because the sign bit
                 *   is not used (zoned-decimal has it own way of signaling negative) and long.MaxValue (vs ulong.MaxValue) is one digit shorter.
                 *   if the value is too big to be represented as a ulong with an implied decimal place (not likely) then you're out of luck and 
                 *   you'll get an exception here
                 */
                ulong workingValue = (ulong)(value * (int)Math.Pow(10, digitsRight));
    
                // the total number of digits that will be output
                int length = digitsLeft + digitsRight;
                
                // more bounds checking (e.g. digitsLeft = 3; digitsRight = 2; if number with implied decimal place > 10^5-1=99999 then it will not fit)
                if (workingValue > Math.Pow(10, length) - 1)
                    throw new ArgumentException("Value exceeds specified total number of fixed digits.", "value");
    
                // each character will be a digit of the number
                char[] output = new char[length];
    
                // loop through the number and output each digit as zoned-decimal
                for (int i = 0; i < length; i++)
                {
                    byte digit = 0;
    
                    // if we run out of digits then we'll just keep looping, padding the specified fixed number
                    // of decimal places with zeros
                    if (workingValue > 0)
                    {
                        // current digit is the one that occupies the right-most place
                        digit = (byte)(workingValue % 10);
                        // shift all values to the right, dropping the current right-most value in the process
                        workingValue /= 10;
                    }
    
                    // the sign indicator is included in the initial right-most digit only
                    if (i == 0)
                        digit |= isNegative ? MASK_NEGATIVE : MASK_POSITIVE;
                    else
                        digit |= MASK_UNSIGNED;
    
                    // set values of our character array from right to left based on the IBM code page 37 EBCDIC character set
                    output[length - i - 1] = m_IBM037Characters[digit];
                }
    
                return new string(output);
            }
    
            /// <summary>
            /// Returns a decimal from a zoned-decimal
            /// </summary>
            /// <param name="zonedDecimalString">The zoned-decimal string</param>
            /// <param name="digitsRight">Number of digits that should be to the right of the decimal place</param>
            /// <returns></returns>
            public static decimal GetDecimal(string zonedDecimalString, int digitsRight)
            {   
                // we'll do most calculations with ulong since it's significantly faster then calculating with decimal
                ulong value = 0;
                // we'll need a way to determine if the number is negative. this will be signaled in the zone of the right-most character
                bool isNegative = false;
                // this will be used to create the place value of each digit
                ulong multipler = 1;
                // start at the right-hand side of the number and proceed to the left
                int lastIndex = zonedDecimalString.Length - 1;
                for (int i = lastIndex; i >= 0; i--)
                {   
                    // get the EBCDIC code for the character at position i
                    if (!m_IBM037Codes.TryGetValue(zonedDecimalString[i], out byte digit))
                        throw new ArgumentException("Invalid numeric character found in zoned-decimal string", "zonedDecimalString");
    
                    // the right-most character will carry the sign
                    if (i == lastIndex)
                        isNegative = (digit & 0xF0) == MASK_NEGATIVE;
    
                    // strip out the zone
                    digit &= 0x0F;
                    // add the place value of the digit to our return value
                    value += digit * multipler;
                    // multipler goes to the next "place" (tens/hundreds/thousands/etc)
                    multipler *= 10;
                }
    
                // now we're going to deal with decimal places and negatives, so we have to switch to a decimal
                decimal returnValue = value;
    
                // deal with digits to the right of the decimal
                if (digitsRight > 0)
                    returnValue /= (int)Math.Pow(10, digitsRight);
    
                // deal with negative
                if (isNegative)
                    returnValue = -returnValue;
    
                return returnValue;
            }
        }
    }
