    protected void Page_Load(object sender, System.EventArgs e)
    {
    	if (ddlMains5.Items.Count <= 1 ) {
    		MyList.DataSource = MyDataSource;
    		MyList.DataBind();
    	}
    }
	
	
