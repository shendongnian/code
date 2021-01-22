    public Type[] GetDeclaredInterfaces( Type type )
    {
        if( type == typeof(object) )
            return new Type[ 0 ];    
        Type[] interfaces = type.GetInterfaces();
        Type[] baseInterfaces = interfaces.Where( i => i.BaseType != null && i.BaseType.IsInterface );
        Type[] declaredInterfaces = interfaces.Except( type.BaseType.GetInterfaces() );
        return declaredInterfaces.Except( baseInterfaces );
    }
