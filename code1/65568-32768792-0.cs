    foreach (DataGridViewColumn column in dataGridView.Columns)
    {
        if (/*It's not your special column*/)
        {
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column.Width = column.Width; //This is important, otherwise the following line will nullify your previous command
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
        }
    }
    //Now do the same using Fill instead of AllCells for your special column
