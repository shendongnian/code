    public class A
    {
    }
    public class B : A
    {
    }
    public class MyClass
    {
        private Type _helperType;
        public Type HelperType
        {
            get { return _helperType; }
            set 
            {
                var testInstance = (A)Activator.CreateInstance(value);
                if (testInstance==null)
                    throw new InvalidCastException("HelperType must be derived from A");
                _helperType = value;
            }
        }
    }
