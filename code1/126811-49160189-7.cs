    private void ExecuteWithReflection(string methodName,object parameterObject = null)
    {
        Assembly assembly = Assembly.LoadFile("Assembly.dll");
        Type typeInstance = assembly.GetType("TestAssembly.Main");
    
        if (typeInstance != null)
        {
            MethodInfo methodInfo = typeInstance.GetMethod(methodName);
            ParameterInfo[] parameterInfo = methodInfo.GetParameters();
            object classInstance = Activator.CreateInstance(typeInstance, null);
    		
            if (parameterInfo.Length == 0)
            {
                // there is no parameter we can call with 'null'
                var result = methodInfo.Invoke(classInstance, null);
            }
            else
            {
                var result = methodInfo.Invoke(classInstance,new object[] { parameterObject } );
            }
        }
    }
