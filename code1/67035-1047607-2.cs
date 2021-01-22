    class Foo
    {
        private SomeObject _myObject;
        public SomeObject MyObject
        {
            get
            {
                if( _myObject == null )
                {
                    _myObject = new SomeObject();
                }
                return _myObject;
            }
            set
            {
                // Do you want to only replace it if
                // value is non-null? Or if _myObject is null?
                // Whatever logic you want would go here
                _myObject = value;
            }
        }
    
        public Foo()
        {
            // logic
        }
    }
