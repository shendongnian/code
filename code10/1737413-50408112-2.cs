    public Interface IRequestFactory
    {
        IRequest CreateRequest();
    }
    public class RequestFactory : IRequestFactory
    {
        private IConfigReader configReader;
        public RequestFactory(IConfigReader configReader)
        {
            this.configReader = configReader;
        }
        public IRequest CreateRequest()
        {
            var currentProtocoll = configReader.GetCurrentProtocoll();
            if(currentProtocoll is HTTP)
                return new HttpRequest();
            else
                return new TcpRequest();
        }
    }
