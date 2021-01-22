    private byte[] incrementBytes(byte[] bytes)
    {
        for (var i = bytes.Length - 1; i >= 0; i--)
        {
            if (bytes[i] < byte.MaxValue)
            {
                bytes[i]++;
                break;
            }
            bytes[i] = 0;
        }
        return bytes;
    }
