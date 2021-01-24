	Dictionary<int?, Table1> table1Dictionary = new Dictionary<int?, Table1>();
	var result = connection.Query<Table1, Table2, Table1>(
		sql,
		(table1, table2) =>
		{
		   Table1 table1Entry;
		   if (!table1Dictionary.TryGetValue(table1.Id, out tableEntry))
		   {
			   table1Entry = table1;
			   table1Entry.table2s = new List<Table2>();
			   tableDictionary.Add(table1Entry.Id, table1Entry);
		   }
		   tableEntry.table2s.Add(table2);
		   return table1Entry;
		},
		new
		{
		},
		splitOn: "Id");
