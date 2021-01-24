    public DataTable GetPerDiff(DataTable dt)
    {
        var fDt = new DataTable();
        // Copy columns for customer name and ID
        fDt.Columns.Add(dt.Columns[0].ColumnName, dt.Columns[0].DataType);
        fDt.Columns.Add(dt.Columns[1].ColumnName, dt.Columns[1].DataType);
        // Create the PerDiff columns
        for (int j = 2; j < dt.Columns.Count - 1; j++)
        {
            string colName = "PerDiff" + dt.Columns[j + 1];
            fDt.Columns.Add(colName, dt.Columns[j + 1].DataType);
        }
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            fDt.Rows.Add(dt.Rows[i][0], dt.Rows[i][1]);
            for (int j = 2; j < dt.Columns.Count - 1; j++)
            {
                decimal? month1 = dt.Rows[i].Field<decimal?>(j);
                decimal? month2 = dt.Rows[i].Field<decimal?>(j + 1);
                if (month1 != decimal.Zero)
                {
                    fDt.Rows[i].SetField(j, (month2 - month1) / month1 * 100);
                }
            }
        }
        return fDt;
    }
