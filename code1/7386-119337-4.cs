    public int DeleteSelectedItems()
    {
        int itemsDeleted = 0;
        int count = dataGrid.RowCount;
        for (int i = count - 1; i >=0; --i)
        {
            DataGridViewRow row = dataGrid.Rows[i];
            if (row.Selected == true)
            {
                dataGrid.Rows.Remove(row);
                // count the item deleted
                ++itemsDeleted;
            }
        }
        // commit the deletes made
        if (itemsDeleted > 0) Commit();
    }
