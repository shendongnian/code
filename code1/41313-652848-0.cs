    public object MyMethod()
        {
            var myNewObject = new
            {
                stringProperty = "Hello, World!",
                intProperty = 1337,
                boolProperty = false
            };
    
            return myNewObject;
        }
    
        public T Cast<T>(object obj, T type)
        {
            return (T)obj;
        }
