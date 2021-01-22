    private void ExecuteWithReflection(object parameterObject)
    {
        Assembly assembly = Assembly.LoadFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),"Class1.dll"));
        Type typeInstance = assembly.GetType("<NameSpace if any>.Class1");
    
        if (typeInstance != null)
        {
            MethodInfo methodInfo = typeInstance.GetMethod("Execute");
            ParameterInfo[] parameterInfo = methodInfo.GetParameters();
            object classInstance = Activator.CreateInstance(typeInstance, null);
    
            if (parameterInfo.Length == 0)
            {
                // This works fine as there is no parameter we can call with 'null'
                var result = mi.Invoke(classInstance, null);
            }
            else
            {
                //object[] parametersArray = new object[] { "Hello","bye" }; - these are parameters you can pass if the method receives [] objects
                var result = mi.Invoke(classInstance,new object[] { parameterObject } );
            }
        }
    }
