    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == -1)
        {
            var dgv = (DataGridView)sender;
            var r = e.CellBounds;
            var w = 0;
            if (e.ColumnIndex > -1)
            {
                w = dgv.Columns[e.ColumnIndex].DividerWidth;
                r.Width = r.Width - w;
            }
            e.Graphics.SetClip(r);
            e.Paint(r, DataGridViewPaintParts.All);
            e.Graphics.SetClip(e.CellBounds);
            if (w > 0)
            {
                r = new Rectangle(r.Right - 1, r.Top, w + 1, r.Height);
                using (var brush = new SolidBrush(dgv.GridColor))
                    e.Graphics.FillRectangle(brush, r);
            }
            e.Handled = true;
        }
    }
