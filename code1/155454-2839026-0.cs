    DataTable dt = new DataTable();
    dt.Columns.Add("A", typeof(decimal));
    dt.Columns.Add("B", typeof(decimal));
    dt.Columns.Add("C", typeof(decimal));
    
    dt.Rows.Add();
    dt.Rows[0]["B"] = DBNull.Value;
    dt.Rows[0]["C"] = 3;
    
    dt.Columns["A"].Expression = "ISNULL(B, 0) + ISNULL(C, 0)";
    Console.WriteLine(dt.Rows[0]["A"]);
