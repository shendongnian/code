    public static class DataGridViewExtension 
    {
        // Method for: DataGridView to DataTable conversion
        public static DataTable ToTable(this DataGridView dataGridView, bool onlyVisible=false)
        {
            // Identifiers used are:
            int rowCount = dataGridView.Rows.Count;
            var dataTable = new DataTable();
            var columnTypes = new Dictionary<string, Type>();
            var rowItems = new List<object>();
            // Get the column names and types
            columnTypes = dataGridView.ColumnTypes(onlyVisible);
            // Setup the DataTable column structure
            dataTable.SetupColumns(columnTypes);
            // Get the rows of the DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Get the row as a list to give to the table
                rowItems = row.ToList(onlyVisible);
                // Give the row items to the DataTable
                dataTable.Rows.Add(rowItems.ToArray());
            }
            // Return the data table
            return dataTable;
        }
    }
