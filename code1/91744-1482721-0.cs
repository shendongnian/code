    public class DerivedClass1 : ThirdPartyClass1
    {
        private MyClass _myClass = new MyClass();
        public MyClass myClass
        {
            get
            {
                return _myClass;
            }
        }
    }
