    public static class DataGridViewExtension 
    {
        // Class for: Getting the column names with column types from a DataGridView
        public static Dictionary<string, Type> ColumnTypes(this DataGridView dataGridView, 
            bool onlyVisible=false)
        {
            // Identifiers used are:
            var types = new Dictionary<string, Type>();
   
            // Go through the columns of the view
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (onlyVisible == true && column.Visible == true)
                {
                    types[column.HeaderText] = column.ValueType;
                }
                else if (!onlyVisible)
                {
                    types[Column.HeaderText] = column.ValueType;
                }
            }
            // Return the results
            return types;
        }
    }
    public static class DataGridViewRowExtension
    {
        // Method for: Returning the cells of a row as a List<object>
        public static List<object> ToList(this DataGridViewRow dataGridViewRow,
            bool onlyVisible= false)
        {
            // Identifiers used are:
            var objectList = new List<object>();
            // Go through the row and add the items to the list
            foreach (DataGridViewCell cell in dataGridViewRow.Cells)
            {
                if (onlyVisible == true && cell.Visible == true)
                {
                    objectList.Add(cell.Value);
                }
                else if (!onlyVisible)
                {
                    objectList.Add(cell.Value);
                }
            }
            // Return the list
            return objectList;
        }
    }
    public static class DataTableExtension
    {
        // Method for: Setting up the column structure of a data table using a dictionary holding column name with data type
        public static void SetupColumns(this DataTable dataTable,
            Dictionary<string, Type> columns)
        {
            // Identifiers used are:
            int columnCount = columns.Count;
            // Set up the structure
            foreach (KeyValuePair<string, Type> column in columns)
            {
                dataTable.Columns.Add(column.Key, column.Value);
            }
        }
    }
