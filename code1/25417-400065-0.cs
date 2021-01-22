    /// <summary>
    /// condition > 0 ? val1 : val2
    /// </summary>
    public static int SelGtz(int condition, int val1, int val2)
    {
        uint mask = (uint)(-condition >> (8 * sizeof(int) - 1));
        return val2 + ((val1 - val2) & (int)mask);
    }
    /// <summary>
    /// condition == 0 ? val1 : val2
    /// </summary>
    public static int SelZero(int condition, int val1, int val2)
    {
        uint mask = (uint)((-condition | condition) >> (8 * sizeof(uint) - 1));
        return val1 + ((val2 - val1) & (int)mask);
    }
