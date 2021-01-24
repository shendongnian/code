    DataSet ResultDataSet= new DataSet();
    DataTable customers = myDataset.Tables.Add("Customers");
    customers.Columns.Add("Name");
    customers.Columns.Add("Age");
    customers.Rows.Add("Chris", "25");
    int records=10;   // split the  10 records per table. if 50 records will be there then 5 tables will generate.
    var splittedTables = ResultDataSet.AsEnumerable()
                                    .Select((row, index) => new { row, index })
                                    .GroupBy(x => x.index / records)
                                    .Select(g => g.Select(x => x.row).CopyToDataTable())
                                    .ToArray();
