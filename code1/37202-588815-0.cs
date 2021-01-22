    public class MyClass {
        public S2kBool MyProperty { get; set; }
        public bool MyPropertyBool {
            get
            {
                return (bool)MyProperty;
            }
            set
            {
                MyProperty = value;
            }
        }
    }
