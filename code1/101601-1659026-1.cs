    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rptOutter.DataSource = outterDataSource;
            rptOutter.DataBind();
        }
    
    }
    protected void rptOutter_ItemCreated(object sender, RepeaterItemEventArgs e)
    {
        Repeater r = e.Item.FindControl("rptInner") as Repeater;
        if (r != null)
        {
            rptOutter.DataSource = innerDataSource;
            rptOutter.DataBind();
        }
    
    }
