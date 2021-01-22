    public delegate CollsionType ValidateDelegate< T >(PlayerState<T> state, Vector2 position, CollsionType boundary);
    public static Object ValidateMove;
    public void AnotherFunction< T >(PlayerState< T > state)
    {
         ValidateDelegate<T> ValFunction = (ValidateDelegate<T>)ValidateMove; 
         ValFunction.Invoke<T>(state,SomeParameter,SomeParamter2);
    }
