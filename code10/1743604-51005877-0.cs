    readonly byte[] blank8Bytes = new byte[8];
    // [...]
        AES.IV = blank8Bytes.Concat(IntToBigEndianBytes(seqNum)).ToArray();
    // [...]    
    // https://stackoverflow.com/a/1318948/9526448
    private static byte[] IntToBigEndianBytes(ulong intValue)
    {
        byte[] intBytes = BitConverter.GetBytes(intValue);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(intBytes);
        byte[] result = intBytes;
        return result;
    }
