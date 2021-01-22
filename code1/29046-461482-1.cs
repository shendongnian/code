	private void MyDataGrid_ItemCreated(object sender, DataGridItemEventArgs e)
	{
		// This method will create a subheading row if needed
		if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
		{
			TableCell tc = new TableCell();
			tc.Controls.Add(new LiteralControl("foo"));
				
			InsertDataGridRow(
                (DataGrid)sender,
                e.Item.ItemIndex + 1,
                tc);
		}      
	}
