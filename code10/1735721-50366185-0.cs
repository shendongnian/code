    private void SaveToCSV() {
        DataTable dt = new DataTable();
        dt = ((DataView)mainDataGrid.ItemsSource).ToTable();
        string result = WriteDataTable(dt);
        // The File.Create().Close() is so it closes the filestream after it creates it.
        if (!File.Exists(CSVFilePath)) {
            File.Create(CSVFilePath).Close();
        }
        File.AppendAllText(CSVFilePath, result, UnicodeEncoding.UTF8);
    }
    private string WriteDataTable(DataTable dataTable) {
        string output = "";
        // Need to get the last column so I know when to add a new line instead of comma.
        string lastColumnName = dataTable.Columns[dataTable.Columns.Count - 1].ColumnName;
        // Get the headers from the datatable.
        foreach (DataColumn column in dataTable.Columns) {
            if (lastColumnName != column.ColumnName) {
                output += (column.ColumnName.ToString() + ",");
            }
            else {
                output += (column.ColumnName.ToString() + "\n");
            }
        }
        // Get the actual data from the datatable.
        foreach (DataRow row in dataTable.Rows) {
            foreach (DataColumn column in dataTable.Columns) {
                if (lastColumnName != column.ColumnName) {
                    output += (row[column].ToString() + ",");
                }
                else {
                    output += (row[column].ToString() + "\n");
                }
            }
        }
        return output;
    }
