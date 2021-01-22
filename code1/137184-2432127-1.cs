    DataTable dt = new DataTable();
    
    dt.Columns.Add("DT", typeof(DateTime));
    
    foreach (var item in Enumerable.Range(1, 20))
    {
        dt.Rows.Add(new DateTime(2010, 3, 10, item, 20, 10));
    }
    
    DataRow[] rows = dt.Rows.Cast<DataRow>().Where(dr => 
        ((DateTime)dr["DT"]).ToString("yyyy-MM-dd HH") == "2010-03-10 10")
        .ToArray();
    
    Console.WriteLine(rows.Length);
