    private string[] _columnNames;
    
    protected void grvDetailedStatus_ItemDataBound(object sender,
        DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            _columnNames = new string[e.Item.Cells.Count];
            for (int i = 0; i < _columnNames.Length; i++)
            {
                _columnNames[i] = e.Item.Cells[i].Text;
            }
        }
        else if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Your original code
        }
    }
