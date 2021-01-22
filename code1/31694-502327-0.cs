    static void Main(string[] args)
    {
        var assembly = typeof(Program).Assembly;
        var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute),true)[0];
        var id = attribute.Value;
        Console.WriteLine(id);
    }
