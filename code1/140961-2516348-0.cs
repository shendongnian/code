    public class MyClass
    {
        MyType _myProperty = null;
        public MyType MyProperty
        {    
            get
            {
                if(_myProperty == null)
                    _myProperty = XYZ;
    
                return _myProperty;
            }
        }
    }
