    public void gridStart()
    {
        DataTable dt = new DataTable();
        DataColumn colContactID = new DataColumn("Date", typeof(string));
        DataColumn colContactName = new DataColumn("Caller", typeof(string));
        DataColumn colResult = new DataColumn("Result", typeof(string));
        dt.Columns.Add(colContactID);
        dt.Columns.Add(colContactName);
        dt.Columns.Add(colResult);
        dataGridView1.DataSource = dt;
        // Call method to insert values.
    }
