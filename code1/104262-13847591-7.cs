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
