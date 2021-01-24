    public class Production : BaseModel
    {
        public static readonly Production Instance = new Production();
        private Production() // makes it non-instantiable form outside.
        { }
        ...
    }
