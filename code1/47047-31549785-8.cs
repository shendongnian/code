    protected void Page_Load(object sender, System.EventArgs e)
    {
    	MyList.DataSource = MyDataSource;
    	MyList.DataBind();
    }
	
	protected void MyList_DataBound(object sender, EventArgs e)
	{
		MyList.Items.Insert(0, new ListItem("- Select One -", ""));
	}
