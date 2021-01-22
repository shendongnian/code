    private List<int> _myColumns;
    
    protected void grvDetailedStatus_ItemDataBound(object sender,
        DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Header)
        {
            _myColumns = new List<int>();
    
            for (int i = 0; i < _columnNames.Length; i++)
            {
                switch (e.Item.Cells[i].Text)
                {
                    case "column1":
                    case "column5":
                        // Interesting column, store index
                        _myColumns.Add(i);
                        break;
                }
            }
        }
        else if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            foreach (int i in _myColumns)
            {
                // Your original code:
                System.DateTime cellDate = default(System.DateTime);
                if (System.DateTime.TryParse(e.Item.Cells[i].Text, out cellDate))
                {
                    e.Item.Cells[i].Text = string.Format("{0:d}", cellDate);
                }
            }
        }
    }
