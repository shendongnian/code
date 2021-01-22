    public static object New( this Type type )
    {
        return type.GetConstructor( Type.EmptyTypes ).Invoke( null );
    }
    public static T New<T>( this Type type )
    {
        return (T)type.GetConstructor( Type.EmptyTypes ).Invoke( null );
    }
    
    // usage
    MyParameterless usable = (MyParameterless)type.New();
    MyParameterless usable 2 = type.New<MyParameterless>();
