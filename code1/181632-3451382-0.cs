    public void yourDataGrid_OnItemDataBound(object s, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            // Change the cell index to the column index you want... I just used 0
            e.Item.Cells[0].Text = "Text you want in header.";
        }
    }
