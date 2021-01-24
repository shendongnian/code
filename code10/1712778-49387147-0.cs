    protected void repeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var link = e.Item.FindControl("showSearch") as HtmlControl;
            link.Attributes["onclick"] = $"$('{e.Item.FindControl("divSearch").ClientID}').toggle('medium'); return false;";
        }
    }
