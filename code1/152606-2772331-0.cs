    protected string sessionValue;
    private void Page_Load(...)
    {
    try
    {
    sessionValue = Session["key"].ToString();
    }
    catch
    {
    sessionValue = [defaultValue];
    }
    }
