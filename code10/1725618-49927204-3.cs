	var myList = new List<MyClass>()
	{
		new MyClass("A", new List<MyClass>()
			{
				new MyClass("B"),
				new MyClass("C"),
			}),
		new MyClass("D", new List<MyClass>()
			{
				new MyClass("E")
			})
	};
