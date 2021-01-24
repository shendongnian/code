    dgv_schedule.DataSource = dt.DefaultView; //Selection mode is RowHeaderSelect
    for (int i = 0; i < numberOfColumns; i++)
    {
        dgv_schedule.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
    }
    dgv_schedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect;
