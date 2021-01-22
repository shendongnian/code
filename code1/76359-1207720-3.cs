        protected void DataList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item
                || e.Item.ItemType == ListItemType.AlternatingItem)
            { 
                DataListItem item = e.Item;
                //List<string> or whatever your data source really is...
                List<string> dataItem = item.DataItem as List<string>;
                MyControl lit = (MyControl)item.FindControl("id1");
                lit.PropertyName = dataItem;
            }
        }
