	var myList = new List<MyClass>()
	{
		new MyClass("A")
		{
			Children = new List<MyClass>()
			{
				new MyClass("B"),
				new MyClass("C"),
			}
		},
		new MyClass("D")
		{
			Children = new List<MyClass>()
			{
				new MyClass("E")
			}
		}
	};
