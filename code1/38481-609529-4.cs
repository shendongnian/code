    /// <summary>
    /// Returns an Int32 with a random value across the entire range of
    /// possible values.
    /// </summary>
    public static int NextInt32(this Random rng)
    {
         unchecked
         {
             int firstBits = rng.Next(0, 1 << 4) << 28;
             int lastBits = rng.Next(0, 1 << 28);
             return firstBits | lastBits;
         }
    }
    public static decimal NextDecimal(this Random rng)
    {
         byte scale = (byte) rng.Next(29);
         bool sign = rng.Next(2) == 1;
         return new decimal(rng.NextInt32(), 
                            rng.NextInt32(),
                            rng.NextInt32(),
                            sign,
                            scale);
    }
