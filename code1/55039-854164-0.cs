        public byte[] ParseHexString(string text)
        {
            if ((text.Length % 2) != 0)
            {
                throw new ArgumentException("Invalid length: " + text.Length);
            }
            if (text.StartsWith("0x", StringComparison.InvariantCultureIgnoreCase))
            {
                text = text.Substring(2);
            }
            int arrayLength = text.Length / 2;
            byte[] byteArray = new byte[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                byteArray[i] = byte.Parse(text.Substring(i*2, 2), NumberStyles.HexNumber);
            }
            return byteArray;
        }
