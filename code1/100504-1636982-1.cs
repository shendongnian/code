    Type myType = Type.GetTypeFromProgID("IMyLib.MyClass");
    dynamic
    {
        object obj = Activator.CreateInstance(myType);
        obj.MyMethod("Hello", 3);
    }
