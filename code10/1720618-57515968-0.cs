    private readonly HttpContext mContext;
    public MyClass(IHttpContextAccessor contextAccessor)
    {
        mContext = contextAccessor.HttpContext;
    }
