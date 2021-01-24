    private DataTable DTCopySample()
    {
        int cnt = 0;
        DataTable dt1 = new DataTable();
        dt1.Columns.Add("ID");
        dt1.Columns.Add("aaa");
        dt1.Columns.Add("bbb");
        DataTable dt2 = new DataTable();
        dt2.Columns.Add("ID");
        dt2.Columns.Add("ccc");
        dt2.Columns.Add("bbb");
        dt2.Columns.Add("aaa");
        dt1.Rows.Add();
        dt1.Rows[0]["ID"] = "23";
        dt1.Rows[0]["aaa"] = "val1";
        dt1.Rows[0]["bbb"] = "val2";
        dt1.Rows.Add();
        dt1.Rows[1]["ID"] = "99";
        dt1.Rows[1]["aaa"] = "val99";
        dt1.Rows[1]["bbb"] = "val98";
        string colName = string.Empty;
        foreach (DataRow row in dt1.Rows)
        {
            dt2.Rows.Add();
            foreach (DataColumn col in dt1.Columns)
            {
                dt2.Rows[cnt][col.ColumnName] = row[col.ColumnName].ToString();
            }
            cnt++;
        }
        return dt2;
    }
