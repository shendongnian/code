    public static void MyMethod(TheBaseClass baseclassobject)
    {
        Type enumType = baseclassobject.GetType().GetNestedType("MyEnum");
        var usedforsomething = Enum.GetName(enumType, 1);
        Console.WriteLine(usedforsomething);
    }
