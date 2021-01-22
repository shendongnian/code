    public class SomeController
    {
        private Func<ISomeService> _serviceFactory;
        public SomeController(Func<ISomeService> serviceFactory)
        {
             _serviceFactory = serviceFactory;
        }
    
        public void DoSomeWork()
        {
           var service = _serviceFactory();
           ....
        }
    }
