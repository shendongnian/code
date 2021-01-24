    DataTable table1 = new DataTable();
    table1.Columns.Add("Key");
    table1.Columns.Add("SourceField");
    
    table1.Rows.Add("A101", "V1");
    table1.Rows.Add("A102", "V2");
    table1.Rows.Add("A103", "V3");
    
    DataTable table2 = new DataTable();
    table2.Columns.Add("Name");
    table2.Columns.Add("V1");
    table2.Columns.Add("V2");
    table2.Columns.Add("V3");
    
    table2.Rows.Add("10001", 1, 2, 3);
    
    DataTable table3 = new DataTable();
    table3.Columns.Add("Name");
    table3.Columns.Add("Value");
    table3.Columns.Add("Key");
    
    // LOOP FOR COMPARING THE DIFFERENT COLUMNS AND VALUES FROM DIFFERENT DATATABLES
    foreach (DataRow drtable1 in table1.Rows)
    {
    	foreach (DataRow drtable2 in table2.Rows)
    	{
    		if ( drtable2[Convert.ToString(drtable1["SourceField"])] != null)
    		{
    			table3.Rows.Add(drtable2["Name"], drtable2[Convert.ToString(drtable1["SourceField"])], drtable1["Key"]);
    		}
    	}
    }
