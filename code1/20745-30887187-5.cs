		// 2. Using IEnumerable makes looping and LINQ easier	
		var k=Iterator.IterateAll(x => x<100); // limit iterator to 100
		// 2.a) Use a foreach loop
		foreach(var x in k){ Console.WriteLine(x); } // loop
		// 2.b) LINQ: take 101..200 of endless iteration
		Console.WriteLine(Iterator.IterateAll(x => true).Skip(100).Take(100)); 
