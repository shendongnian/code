    DataTable dt1 = new DataTable();
    dt1.Columns.Add("BatchNo");
    dt1.Columns.Add("Qty");
    
    DataTable dt2 = new DataTable();
    dt2.Columns.Add("BatchNo");
    dt2.Columns.Add("Qty");
    
    for (int i = 0; i < 5; i++)
    {
    	dt1.Rows.Add(i + 1, i + 2);
    	dt2.Rows.Add(i + 1, i + 3);
    }
    
    var result = dt1.AsEnumerable()
    .Join(dt2.AsEnumerable(), d1 => d1["BatchNo"], d2 => d2["BatchNo"], (d1, d2) => new { D1 = d1, D2 = d2 })
    .Select(r => new 
    {
    	BatchNo = Convert.ToInt32( r.D1["BatchNo"] ),
    	QtyDifference = Convert.ToInt32(r.D2["Qty"]) - Convert.ToInt32(r.D1["Qty"])
    });
