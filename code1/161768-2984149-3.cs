    private bool HasEmptyItem(DataView view)
    {
        foreach (DataRow row in view.Table.Rows)
        {
            foreach (DataColumn col in view.Table.Columns)
            {
                if (row[col] == DBNull.Value)
                    return true;
            }
        }
        return false;
    }
