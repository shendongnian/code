    private static readonly int[][] memoizedResults = new int[100000][];
    public static int[] ConvertToArrayOfDigits(int value)
    {
        if (value < 10000)
        {
            int[] memoized = memoizedResults[value];
            if (memoized == null) {
                memoized = ConvertSmall(value);
                memoizedResults[value] = memoized;
            }
            return (int[]) memoized.Clone();
        }
        // We know that value >= 10000
        int size = value < 100000 ? 5
             : value < 1000000 ? 6
             : value < 10000000 ? 7
             : value < 100000000 ? 8
             : value < 1000000000 ? 9
             : 10;
        return ConvertWithSize(value, size);
    }
    private static int[] ConvertSmall(int value)
    {
        // We know that value < 10000
        int size = value < 10 ? 1
                 : value < 100 ? 2;
                 : value < 1000 ? 3 : 4;
        return ConvertWithSize(value, size);
    }
    private static int[] ConvertWithSize(int value, int size)
    {
        int[] digits = new int[size];
        for (int index = size - 1; index >= 0; index--)
        {
            digits[index] = value % 10;
            value = value / 10;
        }
        return digits;
    }
