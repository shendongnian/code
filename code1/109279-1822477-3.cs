    foreach (RepeaterItem item in myRepeater.Items)
    {
        if (item.ItemType == ListItemType.Footer)
        {
            Literal findMe = (Literal)item.FindControl("findMe");
            //Do your stuff
        }
    }
