    public class MyServiceActivator : IHttpControllerActivator
    {
        private readonly InterfaceReader _reader;
        private readonly HttpConfiguration _configuration;
    
        public MyServiceActivator(InterfaceReader reader, HttpConfiguration configuration)
        {
            _reader = reader;
            _configuration = configuration;
        }
    
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            // Change the line below to whatever suits your needs.
            var controller = _reader.CreateController(new MyImplementation());
            return controller;
        }
    }
