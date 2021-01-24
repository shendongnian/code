    class Class1:Observable
    {
        public Class1()
        {            
        }    
    
        string propertyValue;
        public string Property
        {
            get => propertyValue;
            set => SetPropertyAndNotifyIfNeeded(ref propertyValue, value);
        }
    }
