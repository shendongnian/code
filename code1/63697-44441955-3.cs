    private static byte[] GetBytes(BigInteger value, int size)
    {
        byte[] bytes = value.ToByteArray();
        if (size == -1)
        {
            size = bytes.Length;
        }
        if (bytes.Length > size + 1)
        {
            throw new InvalidOperationException($"Cannot squeeze value {value} to {size} bytes from {bytes.Length}.");
        }
        if (bytes.Length == size + 1 && bytes[bytes.Length - 1] != 0)
        {
            throw new InvalidOperationException($"Cannot squeeze value {value} to {size} bytes from {bytes.Length}.");
        }
        Array.Resize(ref bytes, size);
        Array.Reverse(bytes);
        return bytes;
    }
