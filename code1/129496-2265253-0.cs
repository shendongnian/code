    public static class Service<TRequest, TResponse>
      where TRequest : IRequest
      where TResponse : IResponse, new()
    {
      public delegate TResponse UseDelegate();
    
      public TResponse MakeRequest(TRequest request, UseDelegate codeBlock)
      {
        TResponse response = new TResponse();
        response = codeBlock();
    
        return response;
      }
    }
