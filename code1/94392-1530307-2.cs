    private void dataGridView1_CellPainting(object sender, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
    {
        if (e.Value > 0 && e.Value <= 22 )
        {
            e.Graphics.FillRectangle(Color.Green, e.CellBounds);
        }
        else if (e.Value > 22 && e.Value <= 30 )
        {
            e.Graphics.FillRectangle(Color.Grey, e.CellBounds);
        }
        else if (e.Value > 30)
        {
            e.Graphics.FillRectangle(Color.Red, e.CellBounds);
        }
        else
        {
            e.Graphics.FillRectangle(Color.White, e.CellBounds);
        }
    }
