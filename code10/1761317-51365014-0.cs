	var table = new DataTable();
	table.Columns.Add("VariableRowC", typeof(string));
	table.Columns.Add("VariableColumn", typeof(string));
	table.Columns.Add("Whatever", typeof(string));
	
	table.Rows.Add("r140","c080","A");
	table.Rows.Add("r150","c080","B");
	table.Rows.Add("r150","c080","C");
	table.Rows.Add("r010","c080","D");
	table.Rows.Add("r020","c080","E");
	table.Rows.Add("r030","c080","F");
	table.Rows.Add("r060","c080","G");
	table.Rows.Add("r140","c080","H");
	table.Rows.Add("r010","c080","I");
	var result = table.AsEnumerable().GroupBy(d => d.Field<string>("VariableRowC")).Select(e => e.FirstOrDefault());
