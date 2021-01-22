    public static ushort LowWord(uint val)
    {
        return (ushort)val;
    }
    public static ushort HighWord(uint val)
    {
       return (ushort)(val >> 16);
    }
    public static uint BuildWParam(ushort low, ushort high)
    {
        return ((uint)high << 16) | (uint)low;
    }
