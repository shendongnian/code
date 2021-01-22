	class MyClass
	{
		public int First;
		public int Second;
	}
	
	void Main()
	{	
		List<MyClass> sequence = new List<MyClass>()
		{
			new MyClass{ First = 1, Second = 10 },
			new MyClass{ First = 1, Second = 10 },
			new MyClass{ First = 1, Second = 11 },
			new MyClass{ First = 2, Second = 11 },
			new MyClass{ First = 2, Second = 12 },
			new MyClass{ First = 3, Second = 10 }
		};
		
		var lonelyItems = sequence
		
			// remove all those which don't match First
			.GroupBy(x => x.First).Where(g => g.Count() > 1)
			
			// keep only those which don't match Second
			.SelectMany(g => g.GroupBy(x => x.Second)).Where(g => g.Count() == 1); 
		
		foreach (var x in lonelyItems)
			Console.WriteLine(x);
			
		// output: 
		// 1,11
		// 2,11
		// 2,12
	}
