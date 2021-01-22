    static void Main(string[] args)
    {
        string myString;
        MyMethod1(out myString);
        Console.WriteLine(myString);
    
        Console.ReadLine();
    }
    
    
    public static void MyMethod1(out string param1)
    {
        param1 = "Hello";
    }
