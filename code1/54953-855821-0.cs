    private void DataGrid1_ItemDataBound(object sender, 
                     System.Web.UI.WebControls.DataGridItemEventArgs e) 
    {
        if ((e.Item.ItemType == ListItemType.AlternatingItem) || 
                     (e.Item.ItemType == ListItemType.Item)) 
        {
            CheckBox chk = new Checkbox();
            e.Item.Cells[0].Controls.Add(chk);
        }
