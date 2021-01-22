    if (e.Item is GridDataItem)
    {
        bool isWatch = Convert.ToBoolean(e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["IsWatch"]);
        if (isWatch)
        {
            e.Item.Style["Font-Weight"] = "bold";
        }
    }
