    public static DataTable CrossJoinTables(DataTable t1, DataTable t2)
	{
		if (t1 == null || t2 == null)
			throw new ArgumentNullException("t1 or t2", "Both tables must not be null");
		DataTable t3 = t1.Clone();  // first add columns from table1
		foreach (DataColumn col in t2.Columns)
		{
			string newColumnName = col.ColumnName;
			int colNum = 1;
			while (t3.Columns.Contains(newColumnName))
			{
				newColumnName = string.Format("{0}_{1}", col.ColumnName, ++colNum);
			}
			t3.Columns.Add(newColumnName, col.DataType);
		}
		IEnumerable<object[]> crossJoin = 
			from r1 in t1.AsEnumerable()
			from r2 in t2.AsEnumerable()
			select r1.ItemArray.Concat(r2.ItemArray).ToArray();
		foreach(object[] allFields in crossJoin)
		{
			t3.Rows.Add(allFields);
		}
		return t3;
	}
