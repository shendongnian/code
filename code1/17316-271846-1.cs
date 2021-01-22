    private void Repeater1_ItemDataBound(object Sender, RepeaterItemEventArgs e)
    {
        // Make sure you filter for the item you are after
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            PlaceHolder listLocation = (PlaceHolder)e.Item.FindControl("listPlaceHolder");
            var subItems = ((MyClass)e.Item.DataItem).SubItems;
            listLocation.Controls.Add(new LiteralControl("<ul>");
            foreach(var item in subItems)
            {
                listLocation.Controls.Add(new LiteralControl("<li>" + item + "</li>"));
            }
            listLocation.Controls.Add(new LiteralControl("</ul>");
        }
    }
