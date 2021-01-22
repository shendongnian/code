        	public void Test()
	{
		IList<Item> test = MyMethod();
	}
	public IList<Item> MyMethod()
	{
		Item[] items = new Item[] {new Item()};
		return items;
	}
