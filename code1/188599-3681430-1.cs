    //injected in some form
    private readonly IUnityContainer _container;
    
    public override string GetVaryByCustomString(HttpContext context, 
                                                  string varyByCustomTypeArg)
    {
        //for a POST request (postback) force to return back a non cached output
        if (context.Request.RequestType.Equals("POST"))
        {
            return "post" + DateTime.Now.Ticks;
        }
        try
        {
        IOutputCacheVaryByCustom varyByCustom = _container.Resolve<IOutputCacheVaryByCustom>(varyByCustomTypeArg, new DependencyOverride<HttpContext>(context));
        }
        catch(Exception exc)
        {
           throw new ArgumentOutOfRangeException("varyByCustomTypeArg", exc);
        }
        return context.Request.Url.Scheme + varyByCustom.CacheKey;
    }
