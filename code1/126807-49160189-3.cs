    Assembly assembly = Assembly.LoadFile("...Assembly1.dll");
    Type type = assembly.GetType("TestAssembly.Main");
    if (type != null)
    {
        MethodInfo mi = typeInstance.GetType().GetMethod("Execute");
        ParameterInfo[] parameters = mi.GetParameters();
        object classInstance = Activator.CreateInstance(typeInstance.GetType(), null);
        if (parameters.Length == 0)
        {
            // This works fine
            var result = mi.Invoke(classInstance, null);
        }
        else
        {
            object[] parametersArray = new object[] { "Hello","bye" };
            var result = mi.Invoke(classInstance,new object[] { parametersArray } );
        }
    }
