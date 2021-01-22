    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            rptOutter.DataSource = outterDataSource;
            rptOutter.DataBind();
        }
    
    }
    protected void rptOutter_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        RepeaterItem item = e.Item;
        if ((item.ItemType == ListItemType.Item) ||
            (item.ItemType == ListItemType.AlternatingItem))
        {
            //get your datasource from parent repeater if needed
            //cast to your datasource type
            //DataSourceObject ds = (DataSourceObject)item.DataItem;
            Repeater r = e.Item.FindControl("rptInner") as Repeater;
            if (r != null)
            {
                rptOutter.DataSource = innerDataSource;
                rptOutter.DataBind();
            }
        }
    
    }
