    private static void ExecuteFromAssembly(Assembly assembly)
    {
        Type fooType = assembly.GetType("Foo");
        MethodInfo printMethod = fooType.GetMethod("Print");
        object foo = assembly.CreateInstance("Foo");
        printMethod.Invoke(foo, BindingFlags.InvokeMethod, null, null, CultureInfo.CurrentCulture);
    }
