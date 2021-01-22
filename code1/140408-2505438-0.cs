    DataTable dt = new DataTable();
    dt.Columns.Add("Id", typeof(int));
    dt.Columns.Add("Customer", typeof(string));
    dt.Rows.Add(new Object[] { 24, "Peter Parker" });
    dt.Rows.Add(new Object[] { 42, "Bruce Wayne" });
    
    var query = Enumerable.Range(1, 5).All(i =>
                {
                    var row = dt.NewRow();
                    row["Id"] = i;
                    row[1] = "Customer" + i;
                    dt.Rows.Add(row);
                    return true;
                });
    
    foreach (DataRow row in dt.Rows)
    {
        Console.WriteLine("{0}: {1}", row[0], row[1]);
    }
