    public static Decimal NextDecimal(this Random rng)
    {
        byte[] bytes = new byte[16];
        rng.NextBytes(bytes);
        using (MemoryStream stream = new MemoryStream(bytes))
        {
            return new BinaryReader(stream).ReadDecimal();
        }
    }
    
