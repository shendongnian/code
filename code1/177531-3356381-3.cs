    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
    {
         DataRowView row = (DataRowView)e.Item.DataItem;
         Repeater nestedRepeater = e.Item.FindControl("NestedRepeater") as Repeater;
         nestedRepeater.DataSource = getSavingPerCustomer(row["customerID"]);
         nestedRepeater.DataBind();
     }
