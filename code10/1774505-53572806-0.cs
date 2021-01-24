    private readonly HttpContext _httpContext;
    public ClaimCookie(IHttpContextAccessor contextAccessor)
    {
        _httpContext = contextAccessor.HttpContext;
    }
