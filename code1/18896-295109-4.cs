    public class MyClass
    {
        // this is a field.  It is private to your class and stores the actual data.
        private string _myField;
        // this is a property.  When you access it uses the underlying field, but only exposes
        // the contract that will not be affected by the underlying field
        public string MyField
        {
            get
            {
                return _myField;
            }
            set
            {
                _myField = value;
            }
        }
    }
