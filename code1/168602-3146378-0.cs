    delegate bool ValidateDelegate(Program program, out bool validatedControlAllowsFocusChange);
    static void Main(string[] args)
    {
        var type = typeof(Program);
        var methodInfo = type.GetMethod("ValidateActiveControl", BindingFlags.Instance | BindingFlags.NonPublic);
        var p1 = Expression.Parameter(type, "program");
        var p2 = Expression.Parameter(typeof(bool).MakeByRefType(), "validatedControlAllowsFocusChange");
        var invokeExpression = Expression.Call(p1, methodInfo, p2);
        var func = Expression.Lambda<ValidateDelegate>(invokeExpression, p1, p2).Compile();
        var validatedControlAllowsFocusChange = true;
        // I would expect validatedControlAllowsFocusChange to be false after execution...
        Console.WriteLine(func.Invoke(new Program(), out validatedControlAllowsFocusChange));
        Console.WriteLine(validatedControlAllowsFocusChange);
    }
