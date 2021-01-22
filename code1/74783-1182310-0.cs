    protected void grvDetailedStatus_ItemDataBound(object sender, DataGridItemEventArgs e)
    { 
        if(e.Item.ItemType == ListItemType.Header))
        {
            // retrieve the header text... e.g.
            string FirstCellHeader = e.Item.Cells[0].Text;
        }
        else if((e.Item.ItemType == ListItemType.Item) || 
             (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            // your code for items
        }
    }
