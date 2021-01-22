    public void Type[] GetDeclaredInterfaces( Type type )
    {
        if( type == typeof(object) )
            return new Type[ 0 ];    
        Type[] interfaces = type.GetInterfaces();
        Type[] declaredInterfaces = interfaces.Except( type.BaseType.GetInterfaces() );
    }
