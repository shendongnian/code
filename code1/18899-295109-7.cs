    public class MyClass
    {
        // this is a field.  It is private to your class and stores the actual data.
        private string _myField;
        // this is a property. When accessed it uses the underlying field,
        // but only exposes the contract, which will not be affected by the underlying field
        public string MyProperty
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
        // This is an AutoProperty (C# 3.0 and higher) - which is a shorthand syntax
        // used to generate a private field for you
        public int AnotherProperty{get;set;} 
    }
