    public sealed class MySingleton
    {
        private static readonly MySingleton mySingleton;
        public static MySingleton MySingleton { get { return mySingleton; } }
    
        private MySingleton() {}
    
        static MySingleton() { mySingleton = new MySingleton(); }
    }
