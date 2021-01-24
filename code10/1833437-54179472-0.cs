    	// create the 2 datatables - must have the same schema
    	DataTable  dataTable1 = new DataTable();
    	dataTable1.Columns.Add(new DataColumn("Id"));
    	dataTable1.Columns.Add(new DataColumn("FirstName"));
    	dataTable1.Columns.Add(new DataColumn("LastName"));
    
    	DataTable  dataTable2 = dataTable1.Clone(); 
    	
    	dataTable1.Rows.Add(new object[] {1, "John", "Doe"}); 
    	dataTable1.Rows.Add(new object[] {2, "Peter", "Rabbit"});
    	
    	dataTable2.Rows.Add(new object[] {1, "John", "Doe"});
    	dataTable2.Rows.Add(new object[] {2, "Peter", "Smith"});
    	
    	DataTable resultsTable = dataTable1.Clone();  // table to keep results
    
    	// this will copy all distinct rows into the resultsTable 
    	dataTable1.AsEnumerable()
                .Union(dataTable2.AsEnumerable().Except(dataTable1.AsEnumerable(), DataRowComparer.Default))   // all rows in table2 that do not exists in table1
    		.ToList()	
    		.ForEach(r => resultsTable.ImportRow(r));  // import the distinct rows into the resultsTable.
    
    	DataTable resultsTable2 = dataTable1.Clone();
    	// this will copy only the rows that DO NOT exist in both tables into the resultsTable2 (effectively deletes duplicate rows from both tables)
    	dataTable1.AsEnumerable().Except(dataTable2.AsEnumerable(), DataRowComparer.Default)
                .Union(dataTable2.AsEnumerable().Except(dataTable1.AsEnumerable(), DataRowComparer.Default))   // all rows in table2 that do not exists in table1
    		.ToList()	
    		.ForEach(r => resultsTable2.ImportRow(r));  // import the distinct rows into the resultsTable.
