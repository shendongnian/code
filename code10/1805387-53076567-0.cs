    protected void Page_Load(object sender, EventArgs e)
    {
    	if(!Page.IsPostBack)
    	{
    		List<ListItem> items = new List<ListItem>();
    
    		for (int i = 0; i < 5; i++)
    		{
    			items.Add(new ListItem(DateTime.Now.AddDays(i).ToShortDateString(), DateTime.Now.AddDays(i).ToShortDateString()));
    		}
    		ddldate.DataSource = items;
    		ddldate.DataBind();
    		ddldate.Items[0].Selected = true;
    	}	
    }
