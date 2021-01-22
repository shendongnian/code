    if (e.Item.ItemType == ListItemType.Item ||
         e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)(e.Item.DataItem);
            int rating = int.Parse(drv.Row["rating"].ToString());
            if (rating > 0)
            {
                Label lbl = (Label)e.Item.FindControl("yourLabelIDHere");
                lbl.BackColor = System.Drawing.Color.Green;
            }
        }
