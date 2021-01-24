    private int MyFunction()
    {
        int result = -1;
        int x = int.MinValue;
    
        while (result != 1)
        {
            result = MySmallFunction(out x);
        }
    
        return x;
    }
    
    private int MySmallFunction(out int x)
    {
        x = 1;
        return 1;
    }
