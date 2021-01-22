    static int[] ConvertToArrayOfDigits(int value)
    {
        int size = DetermineDigitCount(value);
        int[] digits = new int[size];
        for (int i=0; i < size; i++)
        {
            digits[size - 1 - i] = value % 10;
            value = value / 10;
        }
        return digits;
    }
    static int DetermineDigitCount(int x)
    {
        return x < 10 ? 1
             : x < 100 ? 2
             : x < 1000 ? 3
             : x < 10000 ? 4
             // etc;
    }
