	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
    	{
        	list_repeater.DataSource = ... getData ..;
	        list_repeater.DataBind();
    	    ...
    	}
    	...
 		foreach(RepeaterItem item in list_repeater.Items) {
			if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
			{
				LinkButton btnCancel = item.FindControl("btnCancel") as LinkButton;
				btnCancel.Click += new EventHandler(btnCancel_Click);
			}
		}
