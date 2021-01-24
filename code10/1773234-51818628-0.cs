	public void Test()
	{
		var l = new List<MyObject>();
		// The following three lines
		var x = new X(my => string.IsNullOrEmpty(my.Name));
		var p = new Predicate<MyObject>(x);
		l.RemoveAll(p);
		// ...will accomplish the same as:
		l.RemoveAll(my => string.IsNullOrEmpty(my.Name));
	}
	private delegate bool X(MyObject m);
	private class MyObject
	{
		public string Name { get; set; }
	}
