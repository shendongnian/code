    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        //Only paint rirst column and RowIndex should be >=0 to avoid rendering column header
        if (e.ColumnIndex == 0 & e.RowIndex >= 0)
        {
            //Paint your tree lines or whatever you want
            using (var treePen = new Pen(Color.Gray, 1))
            {
                treePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                e.Graphics.DrawLine(treePen,
                    new Point(e.CellBounds.Left + 4, e.CellBounds.Top),
                    new Point(e.CellBounds.Left + 4, e.CellBounds.Bottom));
                e.Graphics.DrawLine(treePen,
                    new Point(e.CellBounds.Left + 4, e.CellBounds.Top + e.CellBounds.Height / 2),
                    new Point(e.CellBounds.Left + 12, e.CellBounds.Top + e.CellBounds.Height / 2));
            }
            //Cancel default painting using e.Handled = true
            e.Handled = true;
        }
    }
