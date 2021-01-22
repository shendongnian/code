    grid.CellContentClick += delegate(object obj, DataGridViewCellEventArgs args)
    {
        var cell = (settings_grid[args.ColumnIndex,args.RowIndex] as DataGridViewCheckBoxCell);
        if (cell != null)
        {
            bool new_value = !(bool)cell.Value;                                        
            RecordTheNewState(new_value); // you record the new checkbox state
        }
    };
