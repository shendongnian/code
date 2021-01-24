    private void dataGridView1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle cRect = dataGridView1.ClientRectangle;
        int y0 = 0;
        if (dataGridView1.ColumnHeadersVisible) 
            y0 += dataGridView1.ColumnHeadersHeight;
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            y0 += row.Height;
        }
        int y1 = cRect.Height;
        e.Graphics.FillRectangle(Brushes.White, cRect.Left + 2, y0 , cRect.Right - 3, y1 );
        for (int i = 0; i < colX.Count; i++)
        {
            e.Graphics.DrawLine(Pens.Gray, colX[i]-1, y0, colX[i]-1, y1);
        }
        int y = y0;
        while (y < cRect.Bottom)
        {
            e.Graphics.DrawLine(Pens.Gray, ClientRectangle.Left, y, ClientRectangle.Right, y);
            y += dataGridView1.Rows[0].Height;
        }
    }
