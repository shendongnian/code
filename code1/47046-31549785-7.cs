	protected void Page_Load(object sender, System.EventArgs e)
	{
		if (!IsPostBack) {
			MyList.DataSource = MyDataSource;
			MyList.DataBind();
		}
	}
	
