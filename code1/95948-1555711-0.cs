    static void Main(string[] args)
    {
        var obj = new { Name = "Matt" };
        var val = DoWork(obj); // val == "Matt"
    }
    static object DoWork(object input)
    {
        var inputType = input.GetType();
        var pi = inputType.GetProperty("Name");
        var value = pi.GetValue(input, null);
        return value;
    }
