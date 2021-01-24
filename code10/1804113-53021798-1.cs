	static void sample()
	{
		List<string[]> list = new List<string[]>();
		list.Add(new string[] { "Column 1", "Column 2", "Column 3" });
		list.Add(new string[] { "Row 2", "Row 2" });
		list.Add(new string[] { "Row 3" });
		DataTable table = Convert(list);
		dataGridView1.DataSource = table;
	}
	
