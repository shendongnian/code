    public void gridInsert(string i, string b, string c)
    {
        DataTable dt = (DataTable)myDataGridView.DataSource; 
        DataRow row = dt.NewRow();
        row["Date"] = i;
        row["Caller"] = b;
        row["Result"] = c;
        dt.Rows.Add(row);
        // Call another method to refresh grid view.
    }
