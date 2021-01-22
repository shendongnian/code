    // Only authenticated users can run this code
    if (!HttpContext.Current.SafeGet(s => s.User.Identity.IsAuthenticated))
            return;
    // Get count limit from app.config
    var countLimit = int.Parse(ConfigurationManager.AppSettings.SafeGet(
        s => s.Get("countLimit"),
          "100" // Default 100 if no value is present
        ));
    // Is int 6 a class? Always no, but just to show primitive type usage.
    var is6AClass = 6.SafeGet(i => i.GetType().IsClass);
