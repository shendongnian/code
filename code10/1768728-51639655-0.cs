    namespace Extensions
    {
        // Class for: DataGridView Extensions
        public static class DataGridViewExtension
        {
            // Method for: Getting the DataGridViewColumn by the header text
            public static DataGridViewColumn IndexByHeaderText(this DataGridView dataGridView, 
                string headerText)
            {
                // Identifiers used are:
                DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
                int columnIndex;
                // Get the index (using LinearSearch, at worst O(n), could sort for better)
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    // Check if the header text is found
                    if (column.HeaderText == headerText)
                    {
                        columnIndex = column.Index;
                        return dataGridView.Columns[columnIndex];
                    }
                }
                // Return if not found
                return dataGridViewColumn;
            }
        }
    }
