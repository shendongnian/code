    protected void repComments_OnDataBound(Object sender, RepeaterItemEventArgs e)
    {
        if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
        {
            Panel panel = (Panel)e.Item.FindControl("commentAdminPanel");
            panel.Visible = false;
        }
    }
