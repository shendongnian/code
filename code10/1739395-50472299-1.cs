    void Main()
    {
        Console.WriteLine("You have chosen binary, input a number then it will be converted to binary.");
        string num1input = Console.ReadLine();
        double num1 = double.Parse(num1input);
        
        long bits = BitConverter.DoubleToInt64Bits(num1);
        
        var binary = Convert.ToString(bits, 2);
    
        Console.WriteLine("{0} converted to binary is {1} ", num1, binary);
    }
