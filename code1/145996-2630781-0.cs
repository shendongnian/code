    public static class ExtensionMethods
    {
        public static IEnumerable<byte> Bytes(this Stream stm)
        {
            while (true)
            {
                int c = stm.ReadByte();
                if (c < 0)
                    yield break;
                yield return (byte)c;
            }
        }
        public static IEnumerable<char> Chars(this TextReader reader)
        {
            while (true)
            {
                int c = reader.Read();
                if (c < 0)
                    yield break;
                yield return (char)c;
            }
        }
    }
