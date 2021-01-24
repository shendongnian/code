    public static T Convert<T>(int[] src)
    {
        Type genericClassType = typeof(T);
        Type[] typeParameters = genericClassType.GetGenericArguments();
        Type genericTypeDef = genericClassType.GetGenericTypeDefinition();
        Type constructedClass = genericTypeDef.MakeGenericType(typeParameters);
   
        T arrayLike = (T)Activator.CreateInstance(constructedClass, src);
        
        return arrayLike;
    }
