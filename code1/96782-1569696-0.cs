    public class Class1<T>
    {
        public delegate CollsionType ValidateDelegate<T>(PlayerState<T> state, Vector2 position, CollsionType boundary);
    
        public static ValidateDelegate<T> ValidateMove;
    
        public void AnotherFunction<T>(PlayerState<T> state)
        {
             ValidateDelegate.Invoke<T>(state,SomeParameter,SomeParamter2)
        }
    }
