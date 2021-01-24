    public class Production : BaseModel
    {
        public static readonly Production Instance = new Production();
        private Production() // makes it non-instantiatable form outside.
        { }
        ...
    }
