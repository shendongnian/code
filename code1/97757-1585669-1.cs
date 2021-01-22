    protected string regexPhone = "put regex string here";
    protected string regexEmail = "put regex string here";
    protected string regexBlah = "put regex string here";
    protected void Page_Load(object sender, EventArgs e)
    {
        // We need to call DataBind() on the page so that
        // we can use databinding expressions
        DataBind();
    }
