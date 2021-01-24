    var query = 
		from a in dtPerson.AsEnumerable()
		join b in member on a.Field<string>("ID") equals b.Key into b1
		from b in b1.DefaultIfEmpty()
		select new
		{
			PersonRow  = a,
			MemberType = b.Value?.MemberType ?? String.Empty
		};
	DataTable resultTable = dtPerson.Clone(); // empty same columns
	resultTable.Columns.Add("MemberType");    // add this column
	foreach (var x in query)
	{
		object[] allFields = x.PersonRow.ItemArray.Concat(new []{x.MemberType}).ToArray();
		resultTable.Rows.Add(allFields);
	}
	return resultTable;
