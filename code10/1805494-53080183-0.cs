    public class CountingKsControllerSelector : DefaultHttpControllerSelector
    {
      private HttpConfiguration _config;
      public CountingKsControllerSelector(HttpConfiguration config)
        : base(config)
      {
        _config = config;
      }
      public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
      {
        var controllers = GetControllerMapping();
        var routeData = request.GetRouteData();
        var controllerName = (string)routeData.Values["controller"];
        HttpControllerDescriptor descriptor;
        
        if (controllers.TryGetValue(controllerName, out descriptor))
        {
          [...]
          return descriptor;
        }
        return null;
      }
    }
