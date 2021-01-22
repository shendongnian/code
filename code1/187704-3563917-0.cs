    public int GetDecimalHashCode(decimal value)
    {
        int[] bits = decimal.GetBits(value);
        int hash = 17;
        foreach (int x in bits)
        {
            hash = hash * 31 + x;
        }
        return hash;
    }
