    // Subscribe to DataGridView.MouseDown when convenient
    this.dataGridView.MouseDown += this.HandleDataGridViewMouseDown;
    
    private void HandleDataGridViewMouseDown(object sender, MouseEventArgs e)
    {
        // See where the click is occurring
        DataGridView.HitTestInfo info = this.dataGridView.HitTest(e.X, e.Y);
    
        if (info.Type == DataGridViewHitTestType.Cell)
        {
            switch (info.ColumnIndex)
            {
                // Add and remove case statements as necessary depending on
                // which columns have ComboBoxes in them.
    
                case 1: // Column index 1
                case 2: // Column index 2
                    this.dataGridView.CurrentCell =
                        this.dataGridView.Rows[info.RowIndex].Cells[info.ColumnIndex];
                    break;
                default:
                    break;
            }
        }
    }
