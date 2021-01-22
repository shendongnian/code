  	private Keys _ClickSource = 0;
	private void dgv_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
	{
		if (_ClickSource == 0 || _ClickSource != Keys.Space)
		{
			dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ! (System.Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
		}
		_ClickSource = null;
	}
	private void dgv_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		_ClickSource = e.KeyCode;
	}
