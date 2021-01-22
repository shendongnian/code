    public static class Extensions
    {
        public static String ReadLine(this BinaryReader binaryReader)
        {
            var bytes = new List<Byte>();
            byte temp;
            while ((temp = (byte)binaryReader.Read()) < 10)
                bytes.Add(temp);
            return Encoding.Default.GetString(bytes.ToArray());
        }
    }
