    public class MyHttpControllerFactory : IHttpControllerFactory
    {
        private readonly InterfaceReader _reader;
        private readonly HttpConfiguration _configuration;
    
        public MyHttpControllerFactory(InterfaceReader reader, HttpConfiguration configuration)
        {
            _reader = reader;
            _configuration = configuration;
        }
    
        public IHttpController CreateController(HttpControllerContext controllerContext, string controllerName)
        {
            if (controllerName == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", controllerContext.Request.RequestUri.AbsolutePath));
            }
    
            // Change the line below to whatever suits your needs.
            var controller = _reader.CreateController(new MyImplementation());
            controllerContext.Controller = controller;
            controllerContext.ControllerDescriptor = new HttpControllerDescriptor(configuration, controllerName, controller.GetType());
    
            return controllerContext.Controller;
        }
    
        public void ReleaseController(IHttpController controller)
        {
            // You may want to be able to release the controller as well.
        }
    }
