	public static DataTable CreateTestData()
	{
		var data = new []
		{
			new { ID = 1, Name = "John",  DOB = new DateTime(2018,1,1) },
			new { ID = 2, Name = "Paul",  DOB = new DateTime(2018,1,2) },
			new { ID = 3, Name = "Ringo", DOB = new DateTime(2018,1,3) },
			new { ID = 4, Name = "George",DOB = new DateTime(2018,1,4) }
		};
		var table = new DataTable();
		table.Columns.Add("ID", typeof(int));
		table.Columns.Add("Name", typeof(string));
		table.Columns.Add("DOB", typeof(DateTime));
		foreach (var d in data)
		{
			var row = table.NewRow();
			row[0] = d.ID;
			row[1] = d.Name;
			row[2] = d.DOB;
			table.Rows.Add(row);
		}
		return table;
	}
	
	public static void Main()
	{
		var table = CreateTestData();
		
		var filter1 = new Dictionary<string,object> { {"ID", 1 } };
	    Console.WriteLine("Filter1 exists? {0}", DoesRecordExist(filter1, table));  //Should be true
		var filter2 = new Dictionary<string,object> { { "ID", 1 }, {"Name", "John" } };
	    Console.WriteLine("Filter2 exists? {0}", DoesRecordExist(filter2, table));  //Should be true
		var filter3 = new Dictionary<string,object> { { "ID", 1 }, {"Name", "John" }, {"DOB", new DateTime(2018,1,31)} };
	    Console.WriteLine("Filter3 exists? {0}", DoesRecordExist(filter3, table));  //Should be false
		
		var filter4 = new Dictionary<string,object> { { "ID", 1 }, {"Name", "Paul" }, {"DOB", new DateTime(2018,1,2)} };
	    Console.WriteLine("Filter4 exists? {0}", DoesRecordExist(filter4, table));  //Should be false
	}
