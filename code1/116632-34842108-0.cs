    // Clear all selected cells or rows in the DGV.
    dataGridView1.ClearSelection();
    // Make every column not sortable.
    for (int i=0; i < dataGridView1.Columns.Count; i++)
       dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; 
    // Set selection mode to Column.
    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect; 
    // In case you want the first column selected. 
    if (dataGridView1.Columns.Count > 0 )  // Check if you have at least one column.
        dataGridView1.Columns[0].Selected = true;
