    public ISomeEntity Display<T>( Func<T, ISomeEntity> conversion )
    {
        IsomeEntity display = factory.CreateObject(typeof(T).Name);
        return conversion(display);
    }
