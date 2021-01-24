    private void DisplayData() {
        DataTable dt = new DataTable();
        dt = ConvertToDatatable();
        dataGridView1.DataSource = dt;
    }
    public DataTable ConvertToDatatable() {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("State");
        foreach (var item in listOfPersonState) {
            var row = dt.NewRow();
            row["Name"] = item.Name;
            row["State"] = item.State;
            dt.Rows.Add(row);
        }
        return dt;
    }
