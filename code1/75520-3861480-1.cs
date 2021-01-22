	private void dgvData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		var column = dgvData.Columns[e.ColumnIndex];
		if (column.SortMode != DataGridViewColumnSortMode.Programmatic)
			return;
		var sortGlyph = column.HeaderCell.SortGlyphDirection;
		switch (sortGlyph)
		{
			case SortOrder.None:
			case SortOrder.Ascending:
				dgvData.Sort(column, ListSortDirection.Descending);
				column.HeaderCell.SortGlyphDirection = SortOrder.Descending;
				break;
			case SortOrder.Descending:
				dgvData.Sort(column, ListSortDirection.Ascending);
				column.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				break;
		}
	}
