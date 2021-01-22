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
