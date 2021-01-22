    DataTable dt = yourDataTable;
    foreach (DataColumn col in dt.Columns)
    {
    	BoundField bfield = new BoundField();
    	bfield.DataField = col.ColumnName;
    	bfield.HeaderText = col.ColumnName;
    	dgAssets.Columns.Add(bfield);
    }
