    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != 1)
            return;
        e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
        if (e.Value == null || e.Value == DBNull.Value)
            return;
        var value = (int)e.Value;
        Image img = zero;
        if (value < 0)
            img = negative;
        else if (value > 0)
            img = positive;
        e.Graphics.DrawImage(img, e.CellBounds.Left + 1, e.CellBounds.Top + 1,
            16, e.CellBounds.Height - 3);
        e.Handled = true;
    }
