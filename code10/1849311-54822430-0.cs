    private DataSet Getdataset()
    {
        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("Items", typeof(string));
        dt1.Columns.Add("Status", typeof(bool));
        DataRow dr = dt1.NewRow();
        dr["Items"] = "Hello";
        dr["Status"] = checkBox1.Checked;
        dt1.Rows.Add(dr);
        ds.Tables.Add(dt1);
        dgv1.DataSource = dt1;
        dgv1.AllowUserToAddRows = false;
        ...
        return ds;
    }
