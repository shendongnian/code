    // declaring a data table.. Replace it with whatever code you want
    var table = new DataTable();
    table.Columns.Add("column1", typeof(Decimal));
    table.Columns.Add("column2", typeof(Decimal));
    table.Columns.Add("column3", typeof(Decimal));
    
    // Populate the table
    (from rec in dt.AsEnumerable() 
    where rec.Field<decimal>("column2") == 1 && foo(rec.Field<decimal>("column1"))
    select new {
    	column1 = rec.Field<decimal>("column1"),
    	column2 = rec.Field<decimal>("column2"),
    	column3 = rec.Field<decimal>("column3")})
    	.Aggregate(table, (dt, r) => { dt.Rows.Add(r.column1, r.column2, r.column3); return dt; });
    	
    // at this point your table variable is populated
