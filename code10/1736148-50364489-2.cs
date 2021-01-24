    static int LowestIndex(double[] dbl)
    {
        if (dbl.Length == 0)
        {
            return -1;
        }
        int minIx = 0;
        for (int i = 1; i < dbl.Length; i++)
        {
            if (dbl[i] < dbl[minIx])
            {
                minIx = i;
            }
        }
        return minIx;
    }
