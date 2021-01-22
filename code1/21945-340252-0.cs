    // Fill the DataSet.
    DataSet ds = new DataSet();
    ds.Locale = CultureInfo.InvariantCulture;
    FillDataSet(ds);
    
    List<DataRow> rows = new List<DataRow>();
    
    DataTable contact = ds.Tables["Contact"];
    
    // Get 100 rows from the Contact table.
    IEnumerable<DataRow> query = (from c in contact.AsEnumerable()
                                  select c).Take(100);
    
    DataTable contactsTableWith100Rows = query.CopyToDataTable();
    
    // Add 100 rows to the list.
    foreach (DataRow row in contactsTableWith100Rows.Rows)
        rows.Add(row);
    
    // Create duplicate rows by adding the same 100 rows to the list.
    foreach (DataRow row in contactsTableWith100Rows.Rows)
        rows.Add(row);
    
    DataTable table =
        System.Data.DataTableExtensions.CopyToDataTable<DataRow>(rows);
    
    // Find the unique contacts in the table.
    IEnumerable<DataRow> uniqueContacts =
        table.AsEnumerable().Distinct(DataRowComparer.Default);
    
    Console.WriteLine("Unique contacts:");
    foreach (DataRow uniqueContact in uniqueContacts)
    {
        Console.WriteLine(uniqueContact.Field<Int32>("ContactID"));
    }
