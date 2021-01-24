	var myTable = new DataTable();
	myTable.Columns.Add("Column 3", typeof(double));
	myTable.Rows.Add(20_00_000);
	myTable.Rows.Add(250_000);
	myTable.Rows.Add(185_000);
	myTable.Rows.Add(400_000);
	myTable.Rows.Add(750_000);
	Console.WriteLine(String.Join(", ", myTable.Rows.Cast<DataRow>().Select(r => r.Field<double>("Column 3"))));	
	var max = myTable.Rows.Cast<DataRow>().Max(r => r.Field<double>("Column 3"));
	
	foreach (var row in myTable.Rows.Cast<DataRow>())
	{
		row["Column 3"] = row.Field<double>("Column 3") / max;
	}
	Console.WriteLine(String.Join(", ", myTable.Rows.Cast<DataRow>().Select(r => r.Field<double>("Column 3"))));
