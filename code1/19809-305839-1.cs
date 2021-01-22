    private static MethodInfo GetCorrectMethodInfo(Type typeToCheck)
    {
      MethodInfo returnValue = someCache.Get(typeToCheck.FullName);
 
      if(returnValue == null)
      {
        Type[] paramTypes = new Type[2] { typeof(string), typeToCheck.MakeByRefType() };
        returnValue = typeToCheck.GetMethod("TryParse", paramTypes);
        if (returnValue != null)
        {
          CurrentCache.Add(typeToCheck.FullName, returnValue);
        }
      }
      return returnValue;
    }
