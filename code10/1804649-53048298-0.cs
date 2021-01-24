    public class FooSoapClient : BaseClient, IWebServiceOperations
    {  
        public FooSoapClient() : base(Clients.FooSoap1) 
        public GetFooAsync(...)
        {
             ...
        }  
    }
    public class BaseClient
    {
        private readonly eFooServiceType _serviceType;
        public eFooServiceType ServiceType {
            get{
                return _serviceType;
            }
        }
        protected BaseClient(eFooServiceType service)
        {
            _serviceType = service;
        }
    }
