    private void btnUp_Click(object sender, EventArgs e)
    {
        DataGridView dgv = gridTasks;
        try
        {
            int totalRows = dgv.Rows.Count;
            // get index of the row for the selected cell
            int rowIndex = dgv.SelectedCells[ 0 ].OwningRow.Index;
            if ( rowIndex == 0 )
                return;
            // get index of the column for the selected cell
            int colIndex = dgv.SelectedCells[ 0 ].OwningColumn.Index;
            DataGridViewRow selectedRow = dgv.Rows[ rowIndex ];
            dgv.Rows.Remove( selectedRow );
            dgv.Rows.Insert( rowIndex - 1, selectedRow );
            dgv.ClearSelection();
            dgv.Rows[ rowIndex - 1 ].Cells[ colIndex ].Selected = true;
        }
        catch { }
    }
    private void btnDown_Click(object sender, EventArgs e)
    {
        DataGridView dgv = gridTasks;
        try
        {
            int totalRows = dgv.Rows.Count;
            // get index of the row for the selected cell
            int rowIndex = dgv.SelectedCells[ 0 ].OwningRow.Index;
            if ( rowIndex == totalRows - 1 )
                return;
            // get index of the column for the selected cell
            int colIndex = dgv.SelectedCells[ 0 ].OwningColumn.Index;
            DataGridViewRow selectedRow = dgv.Rows[ rowIndex ];
            dgv.Rows.Remove( selectedRow );
            dgv.Rows.Insert( rowIndex + 1, selectedRow );
            dgv.ClearSelection();
            dgv.Rows[ rowIndex + 1 ].Cells[ colIndex ].Selected = true; 
        }
        catch { }
    }
