    DataTable DataTable1 = new DataTable();
    DataTable1.Columns.AddRange(
         new DataColumn[] {
	          new DataColumn("file", typeof(string)),
	          new DataColumn("date", typeof(DateTime)) });
    
    foreach (string f in System.IO.Directory.GetFiles(@"c:\windows"))
        DataTable1.Rows.Add(f, System.IO.File.GetCreationTime(f));
    GridView1.DataSource = DataTable1;
    GridView1.DataBind();
    
