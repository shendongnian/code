    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
    	if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
    	{
    		Domain.Employee employee = (Domain.Employee)e.Item.DataItem;
    		Control myControl = (Control)e.Item.FindControl("controlID");
            //Perform logic
    	}
    }
