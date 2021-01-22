    public class DerivedClass : BaseClass
    {
        int intValue;
    
        public new int MyProperty
        {
            get { return intValue; }
            set { intValue = value; }
        }
    }  
