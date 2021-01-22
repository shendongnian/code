    class Singleton
    {
        private static Singleton instance  = null;
        private Singleton(){}   // private constructor: stops others from using
    
        public static Singleton Instance
        {
            get { return instance ?? (instance = new Singleton()); }
            set {
                    if (null != value)
                    { throw new InvalidValueException(); }
                    else
                    { instance = null; }
                }
        }
    }
    
    
    void SampleUsage()
    {
        Singleton myObj = Singleton.Instance;
        // use myObj for your work...
        myObj.Instance = null;  // The set-operator makes it ready for GC
    }
