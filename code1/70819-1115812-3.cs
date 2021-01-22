    static void Main(string[] args)
    {
        string myString = "Hello";
        MyMethod0(myString);
        Console.WriteLine(myString);
    
        Console.ReadLine();
    }
    
    public static void MyMethod0(string param1)
    {
        param1 = "World";
    }
