    public static void FlipRandomTrueBitLowMem(ref BitArray bits)
    {
        int trueBits = 0;
        for (int i = 0; i < bits.Count; i++)
            if (bits[i])
                trueBits++;
        if (trueBits > 0)
        {
            int flip = rnd.Next(0, trueBits);
            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                {
                    if (flip == 0)
                    {
                        bits[i] = false;
                        break;
                    }
                    flip--;
                }
            }
        }
    }
