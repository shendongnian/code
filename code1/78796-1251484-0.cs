    public string Obfuscate(int x)
    {
        return ToBase32(ToByteArray(x * 63498398));
    }
    public int Deobfuscate(string x)
    {
        return FromByteArray(FromBase32(x)) / 63498398;
    }
