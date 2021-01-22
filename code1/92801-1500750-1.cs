            public class MyClass
        {
            public string MyProperty { get; set; }
            public string AnotherProperty
            {
                get { return _anotherProperty; }
                set { _anotherProperty = value; }
            }
            private string _anotherProperty;
            
            public MyClass(string myProperty, string anotherProperty)
            {
                MyProperty = myProperty; // auto-implemented property initialization
                _anotherProperty = anotherProperty; //property with member variable initialization                
            }
        }
