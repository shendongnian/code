    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
    {
        string myuser = this.User.Identity.Name;
        base.Initialize(requestContext);
    }
