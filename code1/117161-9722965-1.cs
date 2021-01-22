    public static ulong NextUInt64(this Random random)
    {
        Contract.Requires(random != null);
    
        return BitConverter.ToUInt64(random.NextBytes(8), 0);
    }
    public static byte[] NextBytes(this Random random, int byteCount)
    {
        Contract.Requires(random != null);
        Contract.Requires(byteCount > 0);
        Contract.Ensures(Contract.Result<byte[]>() != null &&
                         Contract.Result<byte[]>().Length == byteCount);
    
        var buffer = new byte[byteCount];
        random.NextBytes(buffer);
        return buffer;
    }
