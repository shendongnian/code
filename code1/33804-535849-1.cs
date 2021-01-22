    public static void ApplyDemoMask(FindResponse response, List<string> mask)
    {
        response.ResultTable.AcceptChanges();
        foreach (DataRow row in response.ResultTable.Rows)
        {
            ApplyDemoMask(row, mask);
        }
    }
