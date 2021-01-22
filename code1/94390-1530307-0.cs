    private void dataGridView1_CellPainting(object sender, System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
    {
        If (e.RowIndex == 1)
        {
            e.Graphics.FillRectangle(Color.Red, e.CellBounds);
        }
        else if (e.RowIndex == 2)
        {
            e.Graphics.FillRectangle(Color.Orange, e.CellBounds);
        }
        else
        {
            e.Graphics.FillRectangle(Color.Green, e.CellBounds);
        }
    }
