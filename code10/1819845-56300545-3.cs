    private class LocalHttpContextAccessor : IHttpContextAccessor
    {
      public IServiceProvider serviceProvider { get; private set; }
      public HttpContext httpContext { get; set; }
      public LocalHttpContextAccessor(IServiceProvider serviceProvider)
      {
        this.serviceProvider = serviceProvider;
        this.httpContext = null;
      }
      public HttpContext HttpContext
      {
        get
        {
          return this.httpContext;
        }
        set
        {
          this.httpContext = null;
        }
      }
    }
