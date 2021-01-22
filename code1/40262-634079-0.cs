    DataGridViewRow[] lastSelectedRows = new DataGridViewRow[0];
    void grid_SelectionChanged(object sender, System.EventArgs e) {
        if ((Control.ModifierKeys & Keys.Control) == Keys.Control) {
            foreach (DataGridViewRow row in lastSelectedRows) {
                if (!row.Selected) row.Selected = true;
            }            
        }
        DataGridViewSelectedRowCollection selected = grid.SelectedRows;
        lastSelectedRows = new DataGridViewRow[selected.Count];
        selected.CopyTo(lastSelectedRows, 0);
    }
