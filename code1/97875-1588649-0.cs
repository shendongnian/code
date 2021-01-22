    protected void yourListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        ListViewDataItem dataItem = (ListViewDataItem)e.Item;
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            YourDataSource yourDataSource= (YourDataSource )dataItem.DataItem;            
        }
    }
