    // Your code
    Type elType = Type.GetType(obj);
    Type genType = typeof(GenericType<>).MakeGenericType(elType);
    object obj = Activator.CreateInstance(genType);
    // To execute the method
    MethodInfo method = genType.GetMethod("MyMethod",
        BindingFlags.Instance | BindingFlags.Public);
    method.Invoke(obj, null);
