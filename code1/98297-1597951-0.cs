    static void Main(string[] args)
    {
        var str = "String";
        var obj = new MyObject() { Value = "Object" };
        Console.WriteLine(str); //String
        Console.WriteLine(obj); //Object
        ChangeMe(str);
        ChangeMe(obj);
        Console.WriteLine(str); //String
        Console.WriteLine(obj); //Object
        ChangeMeInner(obj);
        // this is where it can get confusing!!!
        Console.WriteLine(obj); //Inner 
        ChangeMe(ref str);
        ChangeMe(ref obj); 
        Console.WriteLine(str); // Changed
        Console.WriteLine(obj); // Changed
        Console.Read();
    }
    class MyObject
    {
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
    static void ChangeMe(MyObject input)
    {
        input = new MyObject() { Value = "Changed" };
    }
    static void ChangeMeInner(MyObject input)
    {
        input.Value = "Inner";
    }
    static void ChangeMe(string input)
    {
        input = "Changed";
    }
    static void ChangeMe(ref MyObject input)
    {
        input = new MyObject() { Value = "Changed" };
    }
    static void ChangeMe(ref string input)
    {
        input = "Changed";
    }
