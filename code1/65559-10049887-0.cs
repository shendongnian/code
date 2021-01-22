	grd.DataSource = DT;
	grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
	grd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
	grd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
	for ( int i = 0; i < grd.Columns.Count; i++ )
	{
		int colw = grd.Columns[i].Width;
		grd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		grd.Columns[i].Width = colw;
	}
