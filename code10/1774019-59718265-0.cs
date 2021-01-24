	private void AutoResizeGrid()
		{
			if (dataGridView.Columns.Count < 1) return;
			dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
			dataGridView.AutoResizeRows(DataGridViewAutoSizeRowsMode.DisplayedCells);
		}
		private void MatrixDataGridView_ClientSizeChanged(object sender, EventArgs e)
		{
			if (!this.Visible) return;
			AutoResizeGrid();
		}
		private void MatrixDataGridView_Scroll(object sender, ScrollEventArgs e)
		{
			if (!this.Visible) return;
			AutoResizeGrid();
		}
