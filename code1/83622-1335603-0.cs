    void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        TrackedSet set = this._setLogBindingSource[e.RowIndex] as TrackedSet;
        if (set.IsFlagged)
        {
            e.CellStyle.BackColor = Color.Blue;
            e.CellStyle.ForeColor = Color.White;
        }
        else if (set.IsError)
        {
            e.CellStyle.BackColor = Color.Red;
            e.CellStyle.ForeColor = Color.Blue;
        }
    }
