    string imageGuid = context.Request.QueryString[image];
    MemoryStream ms = (MemoryStream)HttpRuntime.Cache[imageGuid];
    // configure context.Response with appropriate content type and cache settings
    // ** Edit **
    // It seems I need to be more explicit with regard to the above comment:-
    context.Response.Cache.SetCacheability(HttpCacheability.Public);
    context.Response.Cache.SetLastModified(DateTime.UtcNow);
    context.Response.Cache.SetExpires(DateTime.UtcNow.AddHours(2);
    context.Response.Cache.SetMaxAge(TimeSpan.FromHours(2));
    context.Response.Cache.SetValidUntilExpires(true);
    ms.WriteTo(context.Response.OutputStream);
