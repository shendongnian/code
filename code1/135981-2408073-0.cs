    DataTable DataTable1 = new DataTable();
    DataTable1.Columns.AddRange(
         new DataColumn[] {
	          new DataColumn("file", typeof(string)),
	          new DataColumn("date", typeof(DateTime)) });
    
    DataTable1.Rows.Add(@"c:\filename", "2009-03-09");
    
