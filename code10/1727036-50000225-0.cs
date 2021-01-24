    class GridForm : Form
    {
    	private DataTable _table = new DataTable();
    	private DataGridView _grid = new DataGridView();	
    
    	public GridForm()
    	{
    		_table.Columns.Add("Col1", typeof(double));
    		_table.Columns.Add("Col2", typeof(double));
    		_table.Columns.Add("Col3", typeof(double));
    		_table.Columns.Add("Col4", typeof(double));
    
    		var calcCol = _table.Columns.Add("Calc", typeof(double));
    		calcCol.DefaultValue = 0.0d;
    		_table.RowChanged += (sender, args) =>
    		{
    
    			// 4 first columns as doubles
    			var vals = args.Row.ItemArray.Take(4).Cast<double>().ToArray();
    			var calc = vals.Max() - vals.Min();
    
    			// Only set if changed to avoid infinite loop
    			if (!double.Equals(args.Row["Calc"], calc))
    			{
    				args.Row["Calc"] = calc;
    			}
    		};
    
    		_table.LoadDataRow(new object[] {
    			1d, 1d, 3d, 4d
    		}, true);
    		_table.LoadDataRow(new object[] {
    			2d, 2d, 5d, 6d
    		}, true);
    
    		Controls.Add(_grid);
    		_grid.DataSource = _table;
    		_grid.Columns["Calc"].ReadOnly = true;
    		_grid.Dock = DockStyle.Fill;
    		_grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
    		_grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
    		_grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    	}
    }
