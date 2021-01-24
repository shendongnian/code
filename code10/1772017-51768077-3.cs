    public class MyModule
    {
        public MyModule() 
        {
            Get["/"] = IndexHandler;
            Get["/index"] = IndexHandler;
        }
    
        private object IndexHandler(dynamic parameters) {
            this.RequestHandler = new RequestHandler();
            return this.RequestHandler.HandleRequest("/", parameters, someOtherInfo);
        }
    }
