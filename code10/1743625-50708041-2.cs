    private readonly HttpContext Context;
    public MyServiceController(IHttpContextAccessor contextAccessor, ...)
    {
        Context = contextAccessor.HttpContext;
    }
