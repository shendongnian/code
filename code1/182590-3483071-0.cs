       DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
    
       ListSortDirection direction;
       if (dataGridView1.SortOrder == SortOrder.Ascending) direction = ListSortDirection.Ascending;
       else direction = ListSortDirection.Descending;
    
       databaseUpdateFunction();
       DataGridViewColumn newColumn = dataGridView1.Columns[oldColumn.Name.ToString()];
       dataGridView1.Sort(newColumn,direction);
       newColumn.HeaderCell.SortGlyphDirection =
                        direction == ListSortDirection.Ascending ?
                        SortOrder.Ascending : SortOrder.Descending;
