    public static UInt16 EndiannessSwap(UInt16 data)
    {
        var intAsBytes = BitConverter.GetBytes(data);
        Array.Reverse(intAsBytes);
        return BitConverter.ToUInt16(intAsBytes, 0);
    }
