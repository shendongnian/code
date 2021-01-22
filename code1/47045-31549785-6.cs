    protected void Page_Load(object sender, System.EventArgs e)
    {
    	if (MyList.Items.Count <= 1 ) {
    		MyList.DataSource = MyDataSource;
    		MyList.DataBind();
    	}
    }
	
	
