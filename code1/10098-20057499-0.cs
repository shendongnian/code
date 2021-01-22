    void Main()
    {
    	FormatDecimal(23.94742M);
    	FormatDecimal(43M);
    	FormatDecimal(0M);
    	FormatDecimal(0.007M);
    }
    
    public void FormatDecimal(decimal val)
    {
    	Console.WriteLine("ToString: {0}", val);
    	Console.WriteLine("c: {0:c}", val);
    	Console.WriteLine("0.00: {0:0.00}", val);
    	Console.WriteLine("0.##: {0:0.##}", val);
    	Console.WriteLine("===================");
    }
