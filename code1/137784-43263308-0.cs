	// Remember the vertical scroll position of the DataGridView
	int saveVScroll = 0;
	if (DataGridView1.Rows.Count > 0)
		saveVScroll = DataGridView1.FirstDisplayedCell.RowIndex;
	// Remember the horizontal scroll position of the DataGridView
	int saveHScroll = 0;
	if (DataGridView1.HorizontalScrollingOffset > 0)
		saveHScroll = DataGridView1.HorizontalScrollingOffset;
	// Refresh the DataGridView
	DataGridView1.DataSource = ds.Tables(0);
	// Go back to the saved vertical scroll position if available
	if (saveVScroll != 0 && saveVScroll < DataGridView1.Rows.Count)
		DataGridView1.FirstDisplayedScrollingRowIndex = saveVScroll;
	// Go back to the saved horizontal scroll position if available
	if (saveHScroll != 0)
		DataGridView1.HorizontalScrollingOffset = saveHScroll;
