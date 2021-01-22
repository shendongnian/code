	private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
	{
		var column = DataGridView1.Columns[e.ColumnIndex];
		if (column.SortMode != DataGridViewColumnSortMode.Programmatic)
			return;
		var sortGlyph = column.HeaderCell.SortGlyphDirection;
		switch (sortGlyph)
		{
			case SortOrder.None:
			case SortOrder.Ascending:
				DataGridView1.Sort(column, ListSortDirection.Descending);
				column.HeaderCell.SortGlyphDirection = SortOrder.Descending;
				break;
			case SortOrder.Descending:
				DataGridView1.Sort(column, ListSortDirection.Ascending);
				column.HeaderCell.SortGlyphDirection = SortOrder.Ascending;
				break;
		}
	}
