    protected void rptOuter_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            ((Label)e.Item.FindControl("lblFirst")).Text = "New Text";
            ((Repeater)e.Item.FindControl("rptInner")).DataSource = "";
            ((Repeater)e.Item.FindControl("rptInner")).DataBind();//bind data to inner repeater..
        }
    }
