    internal static void RegisterJavascriptInclude(Page page, string includeFile)
    {
        string key = includeFile.ToLowerInvariant();
    
        if (!page.ClientScript.IsClientScriptIncludeRegistered(key))
            page.ClientScript.RegisterClientScriptInclude(key, page.ResolveClientUrl(includeFile));
    }
