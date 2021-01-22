    protected void Data_ItemBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.DataItem != null)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                CheckBox control = (CheckBox)e.Item.FindControl("autoChartChkBox");
            }
        }
    }
