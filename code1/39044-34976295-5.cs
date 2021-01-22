    public extension ULongEnumerable of ulong
    {
        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = sizeof(ulong); i > 0; i--)
            {
                yield return unchecked((byte)(this >> (i-1)*8));
            }
        }
    }
