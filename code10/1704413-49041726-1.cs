    public static void DoSomething(params ITypedClass[] typedClasses) 
    {
        foreach (var c in typedClasses)
        {
            c.Input(...);
        }
    }
