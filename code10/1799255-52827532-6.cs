    static void Main(string[] args)
    {
        dynamic value = 1;
        Console.WriteLine(value);
    
        int integer = value;
        Console.WriteLine(integer);
    
        value = "Hello World";
        Console.WriteLine(value);
    
        string text = value;
        Console.WriteLine(text);
    
        Console.ReadKey();
    }
    // OUTPUT
    // 1
    // 1
    // Hello World
    // Hello World
