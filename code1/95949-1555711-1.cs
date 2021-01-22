    static void Main(string[] args)
    {
        var obj = new { Name = "Matt" };
        var val = DoWork(obj); // val == "Matt"
    }
    static object DoWork(object input)
    {
        /* 
           if you make another anonymous type that matches the structure above
           the compiler will reuse the generated class.  But you have no way to 
           cast between types.
        */
        var inputType = input.GetType();
        var pi = inputType.GetProperty("Name");
        var value = pi.GetValue(input, null);
        return value;
    }
