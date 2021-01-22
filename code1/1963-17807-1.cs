    public delegate object FastPropertyGetHandler(object target);    
    
    private static void EmitBoxIfNeeded(ILGenerator ilGenerator, System.Type type)
    {
        if (type.IsValueType)
        {
            ilGenerator.Emit(OpCodes.Box, type);
        }
    }
    
    public static FastPropertyGetHandler GetPropertyGetter(PropertyInfo propInfo)
    {
        // generates a dynamic method to generate a FastPropertyGetHandler delegate
        DynamicMethod dynamicMethod =
            new DynamicMethod(
                string.Empty, 
                typeof (object), 
                new Type[] { typeof (object) },
                propInfo.DeclaringType.Module);
    
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        // loads the object into the stack
        ilGenerator.Emit(OpCodes.Ldarg_0);
        // calls the getter
        ilGenerator.EmitCall(OpCodes.Callvirt, propInfo.GetGetMethod(), null);
        // creates code for handling the return value
        EmitBoxIfNeeded(ilGenerator, propInfo.PropertyType);
        // returns the value to the caller
        ilGenerator.Emit(OpCodes.Ret);
        // converts the DynamicMethod to a FastPropertyGetHandler delegate
        // to get the property
        FastPropertyGetHandler getter =
            (FastPropertyGetHandler) 
            dynamicMethod.CreateDelegate(typeof(FastPropertyGetHandler));
    
    
        return getter;
    }
