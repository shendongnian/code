    private readonly HttpClientHandler _handler;
    public Startup(IHostingEnvironment env, IConfiguration config,
        ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
            Configuration = config;
            _handler = new HttpClientHandler();
            
            _handler.ClientCertificates.Add(FindClientCertificate());//same x509cert2 that proxy server uses
            _handler.AllowAutoRedirect = true;
            
            
            
        }
    .....
    AddOpenIdConnect( scheme, options => {
    ....
    options.BackchannelHttpHandler = _handler;
    ...
    }
