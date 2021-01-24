    public static string GetBitString(BigInteger val, int bytes)
    {
        var valBytes = val.ToByteArray();
        Array.Resize(ref valBytes, bytes);
        return $"bx{string.Join("", new BitArray(valBytes).Cast<bool>().Reverse().Select(c => c ? "1" : "0"))}";
    }
