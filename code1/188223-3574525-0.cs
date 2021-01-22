	static void func(List<string> data)
	{
		if(data.Count > 0)
			data[0] = "Jimmy";
	}
	static void Main(string[] args)
	{
		List<string> lst = new List<string>(1);
		string str = "";
		lst.Add(str);
		func(lst);
		System.Console.WriteLine(lst[0]); //Prints out 'Jimmy'
	}
