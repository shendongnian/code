    static void Main(string[] args)
    {
        SecondClass secondClass = new SecondClass
        {
            Value = "Test"
        };
        MainClass mainClass = new MainClass
        {
            MyStringValue = "String Value",
            MyClassValue = secondClass
        };
        var json = JsonConvert.SerializeObject(mainClass);
        Console.WriteLine(json);
        Console.ReadLine();
    }
