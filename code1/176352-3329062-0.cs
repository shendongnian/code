    public static IEnumerable<object> Convert(byte[] byteData, Type[] types)
    {
        using (var stream = new MemoryStream(byteData))
        using (var reader = new BinaryReader(stream))
        {
            foreach (var type in types)
            {
                if (type == typeof(short))
                {
                    yield return reader.ReadInt16();
                }
                else if (type == typeof(int))
                {
                    yield return reader.ReadInt32();
                }
                else if (type == typeof(sbyte))
                {
                    yield return reader.ReadSByte();
                }
                // ... other types
                else
                {
                    throw new NotSupportedException(string.Format("{0} is not supported", type));
                }
            }
        }
    }
