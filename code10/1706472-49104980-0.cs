    public void GetTypeInfo()
	{
		Orders o = new Orders {customer = new Customer[] {new Customer()}};
		dataSource.Add(o);
		PropertyInfo info1 = dataSource[0].GetType().GetProperty("customer");
		Array c = (Array) info1.GetValue(dataSource[0], null);
			
		Type info2 = c.GetValue(0).GetType();
		PropertyInfo info3 = info2.GetProperty("OtherAddress");
		Debug.WriteLine("type| " + info3.PropertyType.Name);
	}
