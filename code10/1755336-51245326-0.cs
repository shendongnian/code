    private IHttpContextAccessor _accessor;
    public ValuesController(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    public IEnumerable<string> Get()
    {
        var ip = Request.HttpContext?.Connection?.RemoteIpAddress?.ToString();
        return new string[] { ip, "value2" };
    }
