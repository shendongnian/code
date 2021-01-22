        public static string ToByteFormat(int valIn, int digits)
        {
            var bitsString = new StringBuilder(digits);
            int mask = (1 << digits - 1);
            for(int i = 0; i < digits; i++)
            {
                bitsString.Append((valIn & mask) != 0 ? "1" : "0");
                mask >>= 1;
            }
            return bitsString.ToString();
        }
