    using System.Drawing.Drawing2D;
    ..
    private void dataGridView1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle cRect = dataGridView1.ClientRectangle;
        int y0 = 0;
        if (dataGridView1.ColumnHeadersVisible) y0 += dataGridView1.ColumnHeadersHeight;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            y0 += row.Height;
        }
        int y1 = cRect.Height;
        using (SolidBrush brush = new SolidBrush(dataGridView1.DefaultCellStyle.BackColor))
            e.Graphics.FillRectangle(brush, cRect.Left + 2, y0, cRect.Right - 3, y1);
        using (Pen gridPen1 = new Pen(dataGridView1.GridColor, 1f) 
                { DashStyle = DashStyle.Dot })
        using (Pen gridPen2 = new Pen(dataGridView1.GridColor, 1f) 
                { DashStyle = DashStyle.Solid })
        {
            for (int i = 0; i < colX.Count; i++)
                e.Graphics.DrawLine(gridPen1, colX[i] - 1, y0, colX[i] - 1, y1);
            int y = y0;
            while (y < cRect.Bottom)
            {
                e.Graphics.DrawLine(y == y0 ? gridPen2 : gridPen1, 
                                    cRect.Left, y, cRect.Right, y);
                y += dataGridView1.Rows[0].Height;
            }
        }
    }
