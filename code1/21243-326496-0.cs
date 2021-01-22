    static MethodBase GetGenericMethod(Type type, string name, Type[] typeArgs, 
        Type[] argTypes, BindingFlags flags)
    {
        int typeArity = typeArgs.Length;
        var methods = type.GetMethods()
            .Where(m => m.Name == name)
            .Where(m => m.GetGenericArguments().Length == typeArity)
            .Select(m => m.MakeGenericMethod(typeArgs));
        
        return Type.DefaultBinder.SelectMethod(flags, methods.ToArray(), argTypes, null);
    }
