        public interface IRunQuery
        {
            ResultObject RunQuery();
        }
        public class CustomerFacing
        {
            public CustomerFacing()
            {
            }
            private IRunQuery _needed = null;
            internal IRunQuery Needed
            {
                get
                {
                    if (_needed = null)
                    {
                        _needed = new StandardQuery();
                    }
                    return _needed;
                }
                set
                {
                    _needed = value;
                }
            }
            public void DoSomethingForCustomer()
            {
                // Do some stuff.
                result = Needed.RunQuery();
                // Do some more stuff.
            }
        }
