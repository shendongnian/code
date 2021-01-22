    DataTable dt = new DataTable();
    dt.Columns.Add("IntValue", typeof(int));
    dt.Columns.Add("StringValue", typeof(string));
    dt.Rows.Add(1, "1");
    dt.Rows.Add(1, "1");
    dt.Rows.Add(1, "1");
    dt.Rows.Add(2, "2");
    dt.Rows.Add(2, "2");
    
    var x = (from r in dt.AsEnumerable()
            select r["IntValue"]).Distinct().ToList();
