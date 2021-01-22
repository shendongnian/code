    public void Validate(HttpContext context)
    {
        ValidatePath(context.Server.MapPath("App_Data/ErrorCodes.xml"));
    }
    public void ValidatePath(string path)
    {
        XDocument xdoc = XDocument.Load(path);
        ValidateDocument(xdoc);
    }
    public void ValidateDocument(XDocument xdoc)
    {
        // Original code
    }
