    /// <summary>
    /// Gets the current soution base path
    /// </summary>
    /// <returns></returns>
    public static string GetSolutionBasePath()
    {
        var appPath = PlatformServices.Default.Application.ApplicationBasePath;
        var binPosition = appPath.IndexOf("\\bin", StringComparison.Ordinal);
        var basePath = appPath.Remove(binPosition);
        var backslashPosition = basePath.LastIndexOf("\\", StringComparison.Ordinal);
        basePath = basePath.Remove(backslashPosition);
        return basePath;
    }
