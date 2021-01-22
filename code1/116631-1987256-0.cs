    foreach (DataGridViewColumn c in dataGridView1.Columns)
    {
       c.SortMode = DataGridViewColumnSortMode.NotSortable;
       c.Selected = false;
    }
    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
    dataGridView1.Columns[0].Selected = true;
