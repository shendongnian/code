    public class MyClass
    {
        public int MyProperty
        {
            int _backingField;
        
            get
            {
                return _backingField;
            }
            set
            {
                if( _backingField != value )
                {
                    _backingField = value;
                    // Additional logic
                    ...
                }
            }
        }
    }
