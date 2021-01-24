    // In constructor
    dgvItem.CellFormatting += dgvItem_CellFormatting;
    private void dgvItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var dgv = sender as DataGridView;
        if (dgv.Columns[e.ColumnIndex].Name != "Quantity")
        {
            return;
        }
        if (e.Value == null)
        {
            return;
        }
        var quantity = (decimal)e.Value;
        if (quantity < 0)
        {
            e.Value = 0;
        }
    }
