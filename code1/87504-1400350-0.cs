    class Animal<T>
    {
        public static T Create()
        {
            // Don't know what you'll be able to do here
        }
    }
    
    class Dog : Animal<Dog>
    {
        
    }
