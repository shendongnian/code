    static void Main(string[] args)
    {
        //Error: The call is ambigious between the following methods or properties: ShowMessage(FirstClass), ShowMessage(SecondClass)
        ShowMessage(null);
        //Here it is known which type is being used
        ShowMessage((FirstClass)null);
    }
    
    private static void ShowMessage(FirstClass value)
    {
        System.Console.WriteLine(value);
    }
    
    private static void ShowMessage(SecondClass value)
    {
        System.Console.WriteLine(value.ToString());
    }
    
    class FirstClass { }
    class SecondClass { }
