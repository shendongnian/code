    public MyBusinessObjectClass
    {
        public string MyProperty { get; private set; }
    
        private MyBusinessObjectClass (string myProperty)
        {
            MyProperty  = myProperty;
        }
    
        pubilc static MyBusinessObjectClass CreateInstance (string myProperty)
        {
            if (MyBusinessLogicClass.ValidateBusinessObject (myProperty)) return new MyBusinessObjectClass (myProperty);
    
            return null;
        }
    }
    
    public MyBusinessLogicClass
    {
        public static bool ValidateBusinessObject (string myProperty)
        {
            // Perform some check on myProperty
    
            return CheckResult;
        }
    }
