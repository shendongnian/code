    public object Test(string methodName)
    {
       var assembly = Assembly.LoadFile("...Assembly1.dll");
       var type = assembly.GetType("TestAssembly.Main");
    
       if (type == null)
       {
          return null;
       }
    
       var methodInfo = type.GetMethod(methodName);
    
       if (methodInfo == null)
       {
          return null;
       }
    
       var parameters = methodInfo.GetParameters();
       var classInstance = Activator.CreateInstance(type, null);
    
       if (parameters.Length == 0)
       {
          methodInfo.Invoke(classInstance, null);
       }
       else
       {
          var parametersArray = new object[] { "Hello" };           
          return  methodInfo.Invoke(classInstance, parametersArray);
       }
    
       return null;
    }
