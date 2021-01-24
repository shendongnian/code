    namespace ExtensionMethods
    {
        public static class ByteExt
        {
            public static bool ToBool(this byte b) => b != 0;
            public static bool[] ToBoolArray(this byte[] bytes)
            {
                bool[] returnValues = new bool[bytes.Length];
                for (int i = 0; i < bytes.Length; i++)
                    returnValues[i] = bytes[i].ToBool();
                return returnValues;
            }
            // Do same for sbyte
        }
        public static class CharExt
        {
            public static short[] ToBoolArray(this char[] chars)
            {
                short[] returnValues = new bool[chars.Length];
                for (int i = 0; i < chars.Length; i++)
                    returnValues[0] = (short)chars[0];
                return returnValues;
            }
        }
    }
