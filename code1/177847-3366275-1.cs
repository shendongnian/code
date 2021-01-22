    protected void Repeater1_OnItemDataBound(object sender, RepeaterItemEventArgs e) 
    {
    	if ((e.Item.ItemType == ListItemType.Item) || ((e.Item.ItemType == ListItemType.AlternatingItem))) 
    	{
    		XElement User = ((XElement)e.Item.DataItem).Element("Users").Element("User");
    
    		HyperLink hlUrl = ((HyperLink)e.Item.FindControl("hlUrl"));
    
    		hlUrl.NavigateUrl = ((XElement)e.Item.DataItem).Element("Url").Value;
    		hlUrl.Text = User.Element("DisplayName").Value;
    	}
    }
