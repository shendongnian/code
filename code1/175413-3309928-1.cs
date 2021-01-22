    protected void Page_Load(object sender, EventArgs e)
    {
        Response.StatusCode = 404;
        Response.SuppressContent = true;
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
:)~
