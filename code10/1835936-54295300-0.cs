   	public static class UIExtensions
	{
		public static void FormatDGV(this DataGridView dgv)
		{
			dgv.AllowUserToAddRows = false;
			dgv.AllowUserToDeleteRows = false;
			dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dgv.ColumnHeadersVisible = false;
			dgv.RowHeadersVisible = false;
			dgv.MultiSelect = false;
		}
	}
