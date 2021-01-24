    public static string GetBitString(BigInteger val, int bytes)
    {
        byte[] arrayBytes = new byte[bytes];
        var valBytes = val.ToByteArray();
        for (var i = 0; i < valBytes.Length; i++)
        {
            arrayBytes[i] = valBytes[i];
        }
        var arr = new BitArray(arrayBytes);
        return $"bx{string.Join("", arr.Cast<bool>().Reverse().Select(c => c ? "1" : "0"))}";
    }
