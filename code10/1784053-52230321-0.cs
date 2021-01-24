    var dt = new DataTable();
    dt.Columns.Add("Row", typeof(string));
    dt.Columns.Add("Side", typeof(string));
    dt.Columns.Add("Value", typeof(double));
    
    dt.Rows.Add(1, "A", 34.8);
    dt.Rows.Add(1, "B", 33.9);
    dt.Rows.Add(1, "C", 33.1);
    dt.Rows.Add(2, "A", 32.6);
    dt.Rows.Add(2, "B", 32.0);
    dt.Rows.Add(2, "C", 35.7);
    dt.Rows.Add(3, "A", 34.6);
    dt.Rows.Add(3, "B", 34.0);
    dt.Rows.Add(3, "C", 33.5);
    
    var query = dt
    	.AsEnumerable()
    	.GroupBy(x => x.Field<string>("Row"))
    	.Select(x => new
    	{
    		Row = x.Key,
    		A = x.Where(y => y.Field<string>("Side") == "A").Select(z => z.Field<double>("Value")).FirstOrDefault(),
    		B = x.Where(y => y.Field<string>("Side") == "B").Select(z => z.Field<double>("Value")).FirstOrDefault(),
    		C = x.Where(y => y.Field<string>("Side") == "C").Select(z => z.Field<double>("Value")).FirstOrDefault()
    	})
    	.Select(x => new
    	{
    		Row = x.Row,
    		Result = 4 * x.A + 3 * x.B + 2 * x.C
    	})
    	;
    
    foreach (var q in query)
    	Console.WriteLine("Row = {0}, Result = {1}", q.Row, q.Result);
    		 
