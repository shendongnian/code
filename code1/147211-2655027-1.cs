    MethodInfo dynMethod = typeof(W).GetMethod("Func", BindingFlags.Static | BindingFlags.Public);
    object[] argVals = new object[] { "hi", 1 };
    dynMethod.Invoke(null, argVals);
    
    
    Type type = typeof(W);
    Type[] argTypes = new Type[] { typeof(System.String), typeof(System.Int32) };
    ConstructorInfo dynMethod = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, argTypes, null);
    object[] argVals = new object[] { "hi", 1 };
    dynMethod.Invoke(argVals);
    Activator.CreateInstance(typeof(W), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { "hi", 1 }, null);
