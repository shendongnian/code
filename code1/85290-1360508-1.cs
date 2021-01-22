    public sealed class Bar
    {
        private Bar() { }
        // this will be initialized only once
        private static Bar instance = new Bar();
    
        // Do you prefer a Property?
        public static Bar Instance
        {
            get
            {
                return instance;
            }
        }
    
        // or, a Method?
        public static Bar GetInstance()
        {
            return instance;
        }
    }
