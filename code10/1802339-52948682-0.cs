    var joinedRows = from table1 in dtTimeListTable.AsEnumerable()
    				 join table2 in readyDataTable.AsEnumerable() on (decimal) table1["Avnr"] equals (int) table2["Avnr"]
    				 select new { r1 = table1, r2 = table2 };
	foreach (var x in joinedRows)
	{
		object[] fields =
		{
			x.r2.Field<int>("AVNR"), x.r2.Field<string>("Substation"), x.r2.Field<string>("ColumnTitle"),
			x.r2.Field<int>("S6_NAME"), x.r2.Field<string>("Voltage"), x.r1.Field<decimal>("Wert"),
		};
		dtFinal.Rows.Add(fields);
	}
