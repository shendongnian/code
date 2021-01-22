		string test = "hello world";
		Console.WriteLine(test);
		
		test = test.Remove(5, 1);
		test = test.Insert(5, "z");
		
		Console.WriteLine(test);
