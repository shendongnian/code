    protected void myRepeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var varSubject = e.Item.FindControl("ESubject");
            var adjSubject = varSubject.Parent as HtmlTableCell;
            if (adjSubject != null)
            {
                adjSubject.BgColor = "yellow";
            }
        }
    }
