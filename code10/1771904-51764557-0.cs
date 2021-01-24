    static void Main()
    {
        Console.WriteLine("DECIMAL");
        
        decimal dTest = 1.527m;
        var dTest2 = dTest;
        
        while(dTest2 < dTest*1.1m)
        {
            dTest2 = RoundUp(dTest2);
            Console.WriteLine(dTest2);
        }
        
        Console.WriteLine("FLOAT");
        
        float fTest = 1.527f;
        var fTest2 = fTest;
        
        while(fTest2 < fTest*1.1f)
        {
            fTest2 = RoundUp(fTest2);
            Console.WriteLine(fTest2);
        }
    }
    
    static decimal RoundUp(decimal input)
    {
        int precision = BitConverter.GetBytes(decimal.GetBits(input)[3])[2];
        
        decimal factor = (decimal)Math.Pow(10,precision-1);
        
        return Math.Ceiling(input*factor)/factor;
    }
    
    static float RoundUp(float input)
    {
        return (float)RoundUp((decimal)input);
    }
