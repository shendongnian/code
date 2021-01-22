    using System;
    namespace ConversionExtensions
    {
        public static class ByteArrayExtensions
        {
            private readonly static char[] digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            public static string ToHexString(this byte[] bytes)
            {
                char[] hex = new char[bytes.Length * 2];
                int index = 0;
                foreach (byte b in bytes)
                {
                    hex[index++] = digits[b >> 4];
                    hex[index++] = digits[b & 0x0F];
                }
                return new string(hex);
            }
        }
    }
    using System;
    using System.IO;
    namespace ConversionExtensions
    {
        public static class StringExtensions
        {
            public static byte[] ToBytes(this string hexString)
            {
                if (!string.IsNullOrEmpty(hexString) && hexString.Length % 2 != 0)
                {
                    throw new FormatException("Hexadecimal string must not be empty and must contain an even number of digits to be valid.");
                }
                hexString = hexString.ToUpperInvariant();
                byte[] data = new byte[hexString.Length / 2];
                for (int index = 0; index < hexString.Length; index += 2)
                {
                    int highDigitValue = hexString[index] <= '9' ? hexString[index] - '0' : hexString[index] - 'A' + 10;
                    int lowDigitValue = hexString[index + 1] <= '9' ? hexString[index + 1] - '0' : hexString[index + 1] - 'A' + 10;
                    if (highDigitValue < 0 || lowDigitValue < 0 || highDigitValue > 15 || lowDigitValue > 15)
                    {
                        throw new FormatException("An invalid digit was encountered. Valid hexadecimal digits are 0-9 and A-F.");
                    }
                    else
                    {
                        byte value = (byte)((highDigitValue << 4) | (lowDigitValue & 0x0F));
                        data[index / 2] = value;
                    }
                }
                return data;
            }
        }
    }
