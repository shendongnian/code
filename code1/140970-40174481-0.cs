    public class MyType
    {
        public MyType()
        {
            XYZ();
        }
        public void XYZ()
        {
            //some kind of initialization
        }
    }
    public class TestType
    {
        private Lazy<MyType> _myProperty;
        public MyType MyProperty
        {
            get { return _myProperty.Value; }//_myProperty will be null until some code will try to read it
        }
    }
