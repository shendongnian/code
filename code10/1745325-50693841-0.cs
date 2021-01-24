    private void DataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == -1)
        {
            var dgv = (DataGridView)sender;
            using (var brush = new SolidBrush(dgv.GridColor))
                e.Graphics.FillRectangle(brush, e.CellBounds);
            if (e.ColumnIndex > -1)
            {
                var r = e.CellBounds;
                e.Graphics.SetClip(new Rectangle(r.Left, r.Top,
                    r.Width - dgv.Columns[e.ColumnIndex].DividerWidth, r.Height));
            }
        }
    }
