    private int SumAll(params int[][] args)
    {
        int result = 0;
        for (int x = 0; x < args.Length; x++)
        {
            for (int y = 0; y < args[x].Length; y++)
            {
                result += args[x][y];
            }
        }
        return result;
    }
