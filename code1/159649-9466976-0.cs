    public bool Overrides(MethodInfo baseMethod, Type type)
    {
        if(baseMethod==null)
          throw new ArgumentNullException("baseMethod");
        if(type==null)
          throw new ArgumentNullException("type");
        if(!type.IsSubclassOf(baseMethod.ReflectedType))
            throw new ArgumentException(string.Format("Type must be subtype of {0}",baseMethod.DeclaringType));
        while(type!=baseMethod.ReflectedType)
        {
            var methods=type.GetMethods(BindingFlags.Instance|
                                        BindingFlags.DeclaredOnly|
                                        BindingFlags.Public|
                                        BindingFlags.NonPublic);
            if(methods.Any(m=>m.GetBaseDefinition()==baseMethod))
                return true;
            type=type.BaseType;
        }
        return false;
    }
