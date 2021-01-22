    interface IDataContextFactory
    {
        ??? CreateContext();
    }
    
    class DataContextFactory : IDataContextFactory
    {
        public ??? CreateContext()
        {
            // Create and return the LINQ data context here...
        }
    }
    class Foo
    {
        IDataContextFactory _dataContextFactory;
        
        public Foo(IDataContextFactory dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }
        
        void Poll()
        {
            using (var context = _dataContextFactory.CreateContext())
            {
                //...
            }
        }
    }
