    public sealed class MySingleton
    {
        public static MySingleton MySingleton { get; } = new MySingleton();    
        private MySingleton() {}         
        static MySingleton() {}
    }
