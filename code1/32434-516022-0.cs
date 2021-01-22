    public BusinessClass
    {
        public string MyProperty { get; private set; }
    
        private BusinessClass()
        {
        }
        private BusinessClass(string myProperty)
        {
            MyProperty = myProperty;
        }
        
        public static BusinessClass CreateObject(string myProperty)
        {
            // Perform some check on myProperty
            
            if (/* all ok */)
                return new BusinessClass(myProperty);
            
            return null;
        }
    }
