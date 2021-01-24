    public static bool HasSameSignature(MethodInfo m1, MethodInfo m2)
    {
      if (m1.GetGenericArguments().Length != m2.GetGenericArguments().Length)
        return false;
      var args1 = m1.GetParameters();
      var args2 = m2.GetParameters();
      if (args1.Length != args2.Length)
        return false;
      for (var idx = 0; idx < args1.Length; idx++)
      {
        if (!AreEquivalentTypes(args1[idx].ParameterType, args2[idx].ParameterType))
          return false;
      }
      return true;
    }
    static bool AreEquivalentTypes(Type t1, Type t2)
    {
      if (t1 == null || t2 == null)
        return false;
      if (t1 == t2)
        return true;
      if (t1.DeclaringMethod != null && t2.DeclaringMethod != null && t1.GenericParameterPosition == t2.GenericParameterPosition)
        return true;
      if (AreEquivalentTypes(t1.GetElementType(), t2.GetElementType()))
        return true;
      if (t1.IsGenericType && t2.IsGenericType && t1.GetGenericTypeDefinition() == t2.GetGenericTypeDefinition())
      {
        var ta1 = t1.GenericTypeArguments;
        var ta2 = t2.GenericTypeArguments;
        for (var idx = 0; idx < ta1.Length; idx++)
        {
          if (!AreEquivalentTypes(ta1[idx], ta2[idx]))
            return false;
        }
        return true;
      }
      return false;
    }
