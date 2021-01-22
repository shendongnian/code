        private void myDGV_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            // This is used to set tooltiptext for individual cells in the grid.
            if (e.ColumnIndex == 2)  // I only want tooltips for the second column (0-based)
            {
                if (e.RowIndex >= 0)   // When grid is initialized rowindex == 0
                {
                    // e.ToolTipText = "this is a test."; // static example.
                    DataRowView drv = ((DataGridView)sender).Rows[e.RowIndex].DataBoundItem as DataRowView;
                    MyTableRowClass theRow = drv.Row as MyTableRowClass;
                    e.ToolTipText = theRow.Col1  + "\r\n" + theRow.Col2;
                }
            }
        }
