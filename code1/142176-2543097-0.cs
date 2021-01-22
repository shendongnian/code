    static void Main()
    {
        string temp = "blah";
        Test(temp);
        Console.Read();
    }
    
    private static void Test<T>(T input)
    {
        Console.WriteLine(typeof(T).ToString());
    } 
