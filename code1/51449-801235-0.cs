    public static void InvokeMethod(string typeName, string methodName, SomeType objSomeType) {
          Type type = Type.GetType(typeName);
          if(type==null) {
            return;
          }
          object instance = Activator.CreateInstance(type); //Type must have a parameter-less contructor, or no contructor.   
          MethodInfo methodInfo =type.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public);
          if(methodInfo==null) {
            return;
          }
          methodInfo.Invoke(instance, new[] { objSomeType });  
        } 
