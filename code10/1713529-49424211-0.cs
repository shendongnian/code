    var aggregatedRowData = dtDetails.AsEnumerable()
		.Select(r => new
		{
			tid = r.Field<int>("tid"),
			code = r.Field<int>("code"),
			pNameLocal = r.Field<string>("pNameLocal"),
			qty = r.Field<int>("qty"),
			price = r.Field<decimal>("price"),
		})
		.GroupBy(x => new { x.tid, x.code, x.pNameLocal })
		.Select(grp => new
		{
			grp.Key.tid,
			grp.Key.code,
			grp.Key.pNameLocal,
			qty = grp.Sum(x => x.qty),
			price = grp.Sum(x => x.price)
		});
	DataTable aggregatedTable = dtDetails.Clone();  // empty, same columns
	foreach (var x in aggregatedRowData)
		aggregatedTable.Rows.Add(x.tid, x.code, x.pNameLocal, x.qty, x.price);
