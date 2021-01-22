        // Determine whether the column is the same as the last column clicked.
        if (e.Column != sortColumn)
        {
            // Set the sort column to the new column.
            sortColumn = e.Column;
            // Set the sort order to ascending by default.
            listView1.Sorting = SortOrder.Ascending;
        }
        else
        {
            // Determine what the last sort order was and change it.
            if (listView1.Sorting == SortOrder.Ascending)
                listView1.Sorting = SortOrder.Descending;
            else
                listView1.Sorting = SortOrder.Ascending;
        }
    
        // Call the sort method to manually sort.
        listView1.Sort();
        // Set the ListViewItemSorter property to a new ListViewItemComparer
        // object.
        this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column,
                                                          listView1.Sorting);
    
