    public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
    {
       return IsVirtualPath(virtualPath) ? new CacheDependency(HttpContext.Current.Server.MapPath("~/Resource.xml")) 
                                         : Previous.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
    }
