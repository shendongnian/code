    public class Outer<T>
        where T : struct
    {
        public Outer()
        {
            _InnerObject = new Inner(this);
        }
        private void OuterMethod(Inner myInnerObject)
        {
            /* do something */
        }
        private Inner _InnerObject; public Inner InnerObject
        { 
            get { return _InnerObject; } 
        }
        public class Inner
        {
            Outer<T> _Context;
            public Inner(Outer<T> theContext)
            {
                _Context = theContext;
            }
            bool _SomeProperty;
            public bool SomeProperty
            {
                get { return _SomeProperty; }
                set
                {
                    if (value != _SomeProperty)
                    {
                        _SomeProperty = value;
                        _Context.OuterMethod(this);
                    }
                }
            }
        }
    }
