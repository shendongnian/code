    var dictionaries = new object[]
	{
		new Dictionary<string, MyClass>(),
		new ReadOnlyDictionary<string, MyClass>(new Dictionary<string, MyClass>()),
		new CustomReadOnlyDictionary(),
		new CustomDictionary(),
		new CustomGenericDictionary()
	};
