    // Fill the DataSet.
    DataSet ds = new DataSet();
    ds.Locale = CultureInfo.InvariantCulture;
    FillDataSet(ds);
    
    DataTable products = ds.Tables["Product"];
    
    IEnumerable<DataRow> query =
        from product in products.AsEnumerable()
        select product;
    
    Console.WriteLine("Product Names:");
    foreach (DataRow p in query)
    {
        Console.WriteLine(p.Field<string>("Name"));
    }
