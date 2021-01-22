        static readonly char[] _hexDigits = "0123456789abcdef".ToCharArray();
        public static string ToHexString(this byte[] bytes)
        {
            char[] digits = new char[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                int d1, d2;
                d1 = Math.DivRem(bytes[i], 16, out d2);
                digits[2 * i] = _hexDigits[d1];
                digits[2 * i + 1] = _hexDigits[d2];
            }
            return new string(digits);
        }
