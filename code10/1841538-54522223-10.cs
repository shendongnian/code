    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        //We don't need custom paint for row header or column header
        if (e.RowIndex < 0 || e.ColumnIndex != 1) return;
        //We don't need custom paint for null value
        if (e.Value == null || e.Value == DBNull.Value) return;
        //Choose image based on value
        Image img = zero;
        if ((int)e.Value < 0) img = negative;
        else if ((int)e.Value > 0) img = positive;
        //Paint cell
        e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
        e.Graphics.DrawImage(img, e.CellBounds.Left + 1, e.CellBounds.Top + 1,
            16, e.CellBounds.Height - 3);
        //Prevent default paint
        e.Handled = true;
    }
