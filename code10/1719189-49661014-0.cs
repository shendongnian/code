    public RestClient(
        string key,
        Uri baseAddress,
        ISerializer serializer,
        IResponseFactory responseFactory)
        : this(key, baseAddress, new HttpClientAdapter(), serializer, responseFactory)
    {
    }
    public RestClient(
        string key,
        Uri baseAddress,
        IHttpClient httpClient,
        ISerializer serializer,
        IResponseFactory responseFactory)
    {
        _key = key;
        _baseAddress = baseAddress;
        _serializer = serializer;
        _responseFactory = responseFactory;
        
        HttpClient = httpClient;
    }
    IHttpClient HttpClient {get; private set;}
