    public static int GetHighestDigit(int num)
    {
        if (num <= 0)
           return 0; 
        return (int)((double)num / Math.Pow(10f, Math.Floor(Math.Log10(num))));
    }
