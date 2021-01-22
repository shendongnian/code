	DataSet ds = new DataSet();
	ds.ReadXml(@"D:\foo.xml");
	DataTable tbl = ds.Tables["cj"];
	tbl.PrimaryKey = new DataColumn[] { tbl.Columns["a"] };
	DataView view = tbl.DefaultView;
	view.Sort = "a ASC";
	DataTable sortedBy_a = view.ToTable();
	//remove all the CJ tables -- they're currently unsorted
	ds.Tables.Remove("cj");
	//add in all the sorted CJ tables
	ds.Tables.Add(sortedBy_a);
	StringWriter sw = new StringWriter();
	ds.WriteXml(sw);
