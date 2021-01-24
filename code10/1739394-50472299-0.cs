    void Main()
    {
        Console.WriteLine("You have chosen binary, input a number then it will be converted to binary.");
        string num1input = Console.ReadLine();
        int num1 = int.Parse(num1input);
        
        var binary = Convert.ToString(num1, 2);
    
        Console.WriteLine("{0} converted to binary is {1} ", num1, binary);
    }
