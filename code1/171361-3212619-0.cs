    DataSet dataset; //dataset with all datatables (table1, table2, table3)
    DataTable table4; //datatable with the result "union"
    foreach (DataTable dt in dataset.Tables)
    {
        foreach (DataRow dr in dt.Rows)
        {
            DataRow nr = table4.NewRow();
            foreach (DataColumn dc in table4.Columns)
            {
                try
                {
                    nr[dc.ColumnName] = dr[dc.ColumnName];
                }
                catch
                {
                    nr[dc.ColumnName] = "COLUMN NOT FOUND";
                }
            }
            table4.Rows.Add(nr);
        }
    }
