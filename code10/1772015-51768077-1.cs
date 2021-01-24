    public class MyModule
    {
        public MyModule() 
        {
            this.Get("/", IndexHandler);
            this.Get("/index", IndexHandler);
        }
    
        private dynamic IndexHandler(object parameters) {
            this.RequestHandler = new RequestHandler();
            return this.RequestHandler.HandleRequest("/", parameters, someOtherInfo);
        }
    }
