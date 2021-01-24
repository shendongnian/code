    public static void Main(string[] args)
    {
        Console.WriteLine("Begin");
        double[] inputArray = new double[40];
        
        int inputCount = 0;      
        var input = Console.ReadLine();
        while (!input.Equals("exit", StringComparison.OrdinalIgnoreCase) 
            && !input.Equals("continue", StringComparison.OrdinalIgnoreCase)
            && inputCount < 40)
        {
            inputArray[inputCount++] = Convert.ToDouble(input);  
            input = Console.ReadLine();       
        }
        for (int i = 0; i < inputCount; i++)
        {
            Console.Write("{0} ", inputArray[i]);
            Console.WriteLine();
        }
    }
