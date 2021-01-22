        protected static void WriteMinimumInt(BinaryWriter bin, int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            int skip = bytes.Length-1;
            while (bytes[skip] == 0)
            {
                skip--;
            }
            for (int i = 0; i <= skip; i++)
            {
                bin.Write(bytes[i]);
            }
        }
