	public Action Get<T>() {
		return (Action)_dictionary[typeof(T)];
	}
	public static void MyFunc(object o) {
		Console.WriteLine(o.ToString());
	}
	
	public static void Run() {
		var dictionary = new DelegateDictionary();
		dictionary.Register<string>(MyFunc);
		// Can be converted to an indexer so that you can use []'s
		var stringDelegate = dictionary.Get<string>();
		stringDelegate("Hello World");
	}
