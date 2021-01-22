    protected override void Initialize(System.Web.Routing.RequestContext requestContext)
    {
      base.Initialize(requestContext);
      // now Server has been initialized
      folderPath = Server.MapPath("~/uploads"); 
    }
