    public string Obfuscate(long x)
    {
        return ToZBase32(BitConverter.GetBytes(x * 63498398L));
    }
    public long Deobfuscate(string x)
    {
        return BitConverter.ToInt64(FromZBase32(x)) / 63498398L;
    }
