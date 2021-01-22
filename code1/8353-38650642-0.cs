    try
    {
        WebId = new Guid(queryString["web"]);
    }
    catch (FormatException)
    {
        WebId = Guid.Empty;
    }
    try
    {
        WebId = new Guid(queryString["web"]);
    }
    catch (OverflowException)
    {
        WebId = Guid.Empty;
    }
