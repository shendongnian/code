    private void DataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
        // Ignore if a column or row header is clicked
        if (e.RowIndex != -1 && e.ColumnIndex != -1)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewCell clickedCell = sender as DataGridViewCell;
                    
                // Here you can do whatever you want with the cell
                this.DataGridView1.CurrentCell = clickedCell;  // Select the clicked cell, for instance
                // Get mouse position relative to the vehicles grid
                var relativeMousePosition = DataGridView1.PointToClient(Cursor.Position);
                // Show the context menu
                this.ContextMenuStrip1.Show(DataGridView1, relativeMousePosition);
            }
        }
    }
