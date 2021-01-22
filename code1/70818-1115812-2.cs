    static void Main(string[] args)
    {
        string myString;
        MyMethod2(ref myString);
        Console.WriteLine(myString);
    
        Console.ReadLine();
    }
    
    public static void MyMethod2(ref string param1)
    {
        param1 = "Hello";
    }
