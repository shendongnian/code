	var itemsList = new List<Dictionary<string, object>>();
	for (int i = 0; i < 5; i++)
	{
		var num = i + 1;
		var items = new Dictionary<string, object>();
		items.Add("Id", num);
		items.Add("FirstName", "MyFirstName" + num);
		items.Add("LastName", "MyLastName" + num);
		itemsList.Add(items);
	}
	var result = new MockDataReader(itemsList);	
