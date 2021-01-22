    class MyClass : BaseClass
    {
        // Override base property.
        public new bool MyProperty
        {
            get
            {
                return base.MyProperty;
            }
    
            set
            {
                base.MyProperty = value;
                RaiseMyPropertyChangedEvent();
            }
        }
    }
