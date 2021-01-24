    public static void InitializeArray(ref double[] doubleA)
    {
        //array init using foreach
        int i = 0;
        foreach (double dub in doubleA)
        {
            int key = i;
            i = i + 1;
            doubleA[key] = i + .5;
        }
    }
