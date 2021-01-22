    private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
    {
        if (sender is ListView lv)
        {
            ReverseSortOrderAndSort(e.Column, lv);
    
            if (   lv.Columns[e.Column].ImageList.Images.Keys.Contains("Ascending") 
                && lv.Columns[e.Column].ImageList.Images.Keys.Contains("Descending"))
            {
                switch (Order)
                {
                    case SortOrder.Ascending:
                        lv.Columns[e.Column].ImageKey = "Ascending";
                        break;
                    case SortOrder.Descending:
                        lv.Columns[e.Column].ImageKey = "Descending";
                        break;
                    case SortOrder.None:
                        lv.Columns[e.Column].ImageKey = string.Empty;
                        break;
    
                }
            }
                    
        }
    }
