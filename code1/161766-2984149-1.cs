    private bool HasEmptyItem(DataView view)
    {
        foreach (DataRow row in view.Table.Rows)
        {
            foreach (object o in row.ItemArray)
            {
                if (o == null)
                    return true;
            }
        }
        return false;
    }
