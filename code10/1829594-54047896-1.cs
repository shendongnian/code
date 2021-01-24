	public static DataTable CreateTestData()
	{
		var data = new Dictionary<int,string>
		{
			{ 1, "John" },
			{ 2, "Paul" },
			{ 3, "Ringo" },
			{ 4, "George" }
		};
		var table = new DataTable();
		table.Columns.Add("ID", typeof(int));
		table.Columns.Add("Name", typeof(string));
		foreach (var d in data)
		{
			var row = table.NewRow();
			row[0] = d.Key;
			row[1] = d.Value;
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
		var filter3 = new Dictionary<string,object> { { "ID", 1 }, {"Name", "Paul" } };
	    Console.WriteLine("Filter3 exists? {0}", DoesRecordExist(filter3, table));  //Should be false
	}
