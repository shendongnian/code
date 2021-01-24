    [Authorize]
    public IActionResult AuthorizedSpaFallBack()
    {
        var file = _env.ContentRootFileProvider.GetFileInfo("ClientApp/dist/index.html");
        return PhysicalFile(file.PhysicalPath, "text/html");
    }
