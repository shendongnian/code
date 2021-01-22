    public class StorageSingleton
    {
        private static readonly StorageSingleton instance;
        
        static StorageSingleton() { 
             instance = new Singleton();
        }
        // Mark constructor as private as no one can create it but itself.
        private StorageSingleton() 
        { 
            // For constructing
        }
        
        // The only way to access the created instance.
        public static StorageSingleton Instance
        {
            get 
            {
                return instance;
            }
        }        
        // Note that this will be null when the instance if not set to
        // something in the constructor.
        public string FilePath { get; set; }
    }
