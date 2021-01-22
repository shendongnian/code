    grd.DataSource = DT;
    //set autosize mode
    grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    grd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    grd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    //datagrid has calculated it's widths so we can store them
    for (int i = 0; i <= grd.Columns.Count - 1; i++) {
	    //store autosized widths
	    int colw = grd.Columns[i].Width;
	    //remove autosizing
	    grd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
	    //set width to calculated by autosize
	    grd.Columns[i].Width = colw;
    }
