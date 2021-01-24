    DataRow MergeRows(DataTable dt, DataRow row1, DataRow row2)
    {
        var row3 = dt.NewRow();
        for (int i = 0; i < row1.ItemArray.Length; i++)
        {
            row3.SetField(i, row1.ItemArray[i]);
        }
        for (int i = 0; i < row1.ItemArray.Length; i++)
        {
            row3.SetField(i + row1.ItemArray.Length, row2.ItemArray[i]);
        }
        return row3;
    }
