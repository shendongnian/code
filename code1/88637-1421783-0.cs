    // Override the OnMouseClick event.
    protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
    {
        if (base.DataGridView != null)
        {
            // Get the location (Row/Column) of the selected cell.
            Point point1 = base.DataGridView.CurrentCellAddress;
            // e.ColumnIndex/e.RowIndex can be replaced with a hard-coded
            // value if you only want a specific cell, row, or column to
            // be editable.
            if (point1.X == e.ColumnIndex &&
                point1.Y == e.RowIndex &&
                e.Button == MouseButtons.Left &&
                base.DataGridView.EditMode !=
                DataGridViewEditMode.EditProgrammatically)
            {
                // Open the cell to be edited.
                base.DataGridView.BeginEdit(true);
            }
        }
    }
