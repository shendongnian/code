    public class MyDerivedClass : MyBaseClass 
    {
        protected override object MyPropertyValue
        {
            get
            {
                return SomeObjectValue();
            }
        }
    }
