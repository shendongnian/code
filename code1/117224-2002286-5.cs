    public static BitArray FlipRandomTrueBit(BitArray bits)
    {
        List<int> trueBits = new List<int>();
        for (int i = 0; i < bits.Count; i++)
            if (bits[i])
                trueBits.Add(i);
        if (trueBits.Count > 0)
        {
            int index = rnd.Next(0, trueBits.Count);
            bits[trueBits[index]] = false;
        }
        return bits;
    }
