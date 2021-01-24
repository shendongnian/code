    public class ResourcesServicesFactory
    {        
        public ResourcesServicesFactory() { }
        public ResourcesServices Create(IDictionary<string, string> parameters)
        {
            return new ResourcesServices(parameters);
        }
    }   
    public class ChildController : MyBaseController
    {
        private readonly ResourceServiceFactory _factory;
        public ChildController(  
            ILogger<BaseController> logger,
            VVDCCore.Tools.Interfaces.IResourceManager resxManager,
            ResourceServiceFactory factory) : base(logger, resxManager)
        {
            _factory = factory;
        }
        public IActionResult Get()
        {
            var service = _factory.Create(ExtraParameters);
            service.DoSomething();
        }
    }
