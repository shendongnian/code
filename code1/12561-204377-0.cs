    static void Main()
    {
        //use string.Format(str, args) as a test
        var method = typeof (string).GetMethod(
            "Format",
            new[] {typeof(string), typeof (object[])});
        var param = method.GetParameters()[1];
        Console.WriteLine(IsParams(param));
    }
    static bool IsParams(ParameterInfo param)
    {
        return param.GetCustomAttributes(typeof (ParamArrayAttribute), false).Length > 0;
    }
