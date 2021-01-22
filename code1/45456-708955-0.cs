    public PrivateCtorClass
    {
        private PrivateCtorClass()
        {
        }
        
        public static PrivateCtorClass Create()
        {
            return new PrivateCtorClass();
        }
    }
    
    public SomeOtherClass
    {
        public void SomeMethod()
        {
            var privateCtorClass = PrivateCtorClass.Create();
        }
    }
