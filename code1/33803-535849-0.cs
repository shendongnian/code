    public static void ApplyDemoMask(FindResponse response, List<string> mask)
    {
        foreach (DataRow row in response.ResultTable.Rows)
        {
            if (row.RowState != DataRowState.Deleted)
            {
                ApplyDemoMask(row, mask);
            }
        }
    }
