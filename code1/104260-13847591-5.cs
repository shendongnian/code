	private void dgvAccount_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
	{
		if (e.ColumnIndex != -1 && e.RowIndex != -1 && e.Button == System.Windows.Forms.MouseButtons.Right)
		{
			DataGridViewCell c = (sender as DataGridView)[e.ColumnIndex, e.RowIndex];
			if (!c.Selected)
			{
				c.DataGridView.ClearSelection();
				c.DataGridView.CurrentCell = c;
				c.Selected = true;
			}
		}
	}
	private void dgvAccount_KeyDown(object sender, KeyEventArgs e)
	{
		if ((e.KeyCode == Keys.F10 && e.Shift) || e.KeyCode == Keys.Apps)
		{
			DataGridViewCell currentCell = (sender as DataGridView).CurrentCell;
			if (currentCell != null)
			{
				ContextMenuStrip cms = currentCell.ContextMenuStrip;
				if (cms != null)
				{
					Rectangle r = currentCell.DataGridView.GetCellDisplayRectangle(currentCell.ColumnIndex, currentCell.RowIndex, false);
					Point p = new Point(r.X + r.Width, r.Y + r.Height);
					cms.Show(currentCell.DataGridView, p);
				}
			}
		}
	}
