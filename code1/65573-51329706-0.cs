       grd.DataSource = getDataSource();
        if (grd.ColumnCount > 1)
        {
            for (int i = 0; i < grd.ColumnCount-2; i++)
                grd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grd.Columns[grd.ColumnCount-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        if (grd.ColumnCount==1)
            grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
