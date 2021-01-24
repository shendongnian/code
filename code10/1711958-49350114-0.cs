    public abstract class MyBaseClass
    {
        public object MyProperty
        {
            get
            {
                RunSomeMethod();
                return MyPropertyValue;    
            }
        }
        protected abstract object MyPropertyValue { get; }
    }
