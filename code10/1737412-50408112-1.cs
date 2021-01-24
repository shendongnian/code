    public Interface IRequestFactory
    {
        IRequest CreateHttpRequest();
        IRequest CreateTcpRequest();
    }
    public class RequestFactory : IRequestFactory
    {
        // Implementation
    }
