    private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
    	if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
    	{
    		if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected == true)
    		{
    			e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
    			using (Pen p = new Pen(Color.Red, 1))
    			{
    				Rectangle rect = e.CellBounds;
    				rect.Width -= 2;
    				rect.Height -= 2;
    				e.Graphics.DrawRectangle(p, rect);
    			}
    			e.Handled = true;
    		}
    	}
    }
