    protected void Page_Load(object sender, EventArgs e)
    {
        ddlStatus.DataBind();
        // or use Page.DataBind() to bind everything
    }
    public Dictionary<int, string> Statuses
    {
        get 
        {
            // do database/webservice lookup here to populate Dictionary
        }
    };
