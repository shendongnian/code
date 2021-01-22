    public class StorageSingleton
    {
        private static StorageSingleton instance;
        
        // Mark constructor as private as no one can create it but itself.
        private StorageSingleton() { }
        
        // The only way to access the created instance.
        public static StorageSingleton Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new StorageSingleton();
                }
                return instance;
            }
        }        
        // Note that this will be null when the instance is first initialized
        public string FilePath { get; set; }
    }
