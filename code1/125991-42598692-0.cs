    public static string VersionedContent(this HttpContext httpContext, string virtualFilePath)
    {
        var physicalFilePath = httpContext.Server.MapPath(virtualFilePath);
        if (httpContext.Cache[physicalFilePath] == null)
        {
            httpContext.Cache[physicalFilePath] = ((Page)httpContext.CurrentHandler).ResolveUrl(virtualFilePath) + (virtualFilePath.Contains("?") ? "&" : "?") + "v=" + File.GetLastWriteTime(physicalFilePath).ToString("yyyyMMddHHmmss");
        }
        return (string)httpContext.Cache[physicalFilePath];
    }
