    public static class HexTable
    {
        private static readonly string[] table = BitConverter.ToString(Enumerable.Range(0, 256).Select(x => (byte)x).ToArray()).Split('-');
        public static string ToHexTable(byte[] value)
        {
            StringBuilder sb = new StringBuilder(2 * value.Length);
            for (int i = 0; i < value.Length; i++)
                sb.Append(table[value[i]]);
            return sb.ToString();
        }
