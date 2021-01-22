    public static class GenericBaseConverter
    {
        public static string ConvertToString(byte[] valueAsArray, string digits, int pad)
        {
            if (digits == null)
                throw new ArgumentNullException("digits");
            if (digits.Length < 2)
                throw new ArgumentOutOfRangeException("digits", "Expected string with at least two digits");
    
            BigInteger value = new BigInteger(valueAsArray);
            bool isNeg = value < 0;
            value = isNeg ? -value : value;
    
            StringBuilder sb = new StringBuilder(25);
    
            do
            {
                BigInteger rem;
                value = BigInteger.DivRem(value, digits.Length, out rem);
                sb.Append(digits[(int)rem]);
            } while (value > 0);
    
            // pad it
            if (sb.Length < pad)
                sb.Append(digits[0], pad - sb.Length);
    
            // if the number is negative, add the sign.
            if (isNeg)
                sb.Append('-');
    
            // reverse it
            for (int i = 0, j = sb.Length - 1; i < j; i++, j--)
            {
                char t = sb[i];
                sb[i] = sb[j];
                sb[j] = t;
            }
    
            return sb.ToString();
    
        }
        
        public static BigInteger ConvertFromString(string s, string digits)
        {
            BigInteger result;
    
            switch (Parse(s, digits, out result))
            {
                case ParseCode.FormatError:
                    throw new FormatException("Input string was not in the correct format.");
                case ParseCode.NullString:
                    throw new ArgumentNullException("s");
                case ParseCode.NullDigits:
                    throw new ArgumentNullException("digits");
                case ParseCode.InsufficientDigits:
                    throw new ArgumentOutOfRangeException("digits", "Expected string with at least two digits");
                case ParseCode.Overflow:
                    throw new OverflowException();
            }
    
            return result;
        }
    
        public static bool TryParse(string s, string digits, out BigInteger result)
        {
            return Parse(s, digits, out result) == ParseCode.Success;
        }
    
        private enum ParseCode
        {
            Success,
            NullString,
            NullDigits,
            InsufficientDigits,
            Overflow,
            FormatError,
        }
    
        private static ParseCode Parse(string s, string digits, out BigInteger result)
        {
            result = 0;
    
            if (s == null)
                return ParseCode.NullString;
            if (digits == null)
                return ParseCode.NullDigits;
            if (digits.Length < 2)
                return ParseCode.InsufficientDigits;
    
            // skip leading white space
            int i = 0;
            while (i < s.Length && Char.IsWhiteSpace(s[i]))
                ++i;
            if (i >= s.Length)
                return ParseCode.FormatError;
    
            // get the sign if it's there.
            BigInteger sign = 1;
            if (s[i] == '+')
                ++i;
            else if (s[i] == '-')
            {
                ++i;
                sign = -1;
            }
    
            // Make sure there's at least one digit
            if (i >= s.Length)
                return ParseCode.FormatError;
    
    
            // Parse the digits.
            while (i < s.Length)
            {
                int n = digits.IndexOf(s[i]);
                if (n < 0)
                    return ParseCode.FormatError;
                BigInteger oldResult = result;
                result = unchecked((result * digits.Length) + n);
                if (result < oldResult)
                    return ParseCode.Overflow;
    
                ++i;
            }
    
            // skip trailing white space
            while (i < s.Length && Char.IsWhiteSpace(s[i]))
                ++i;
    
            // and make sure there's nothing else.
            if (i < s.Length)
                return ParseCode.FormatError;
    
            if (sign < 0)
                result = -result;
    
            return ParseCode.Success;
        }
    }
