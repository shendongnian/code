		// 2. Using IEnumerable makes looping and LINQ easier	
		var k=Iterator.IterateAll(x => x<100); // limit iterator to 100
		// 2.a) Use a foreach loop
		foreach(var x in k){ Console.WriteLine(x); } // loop
		// 2.b) LINQ: take 101..200 of endless iteration
		var lst=Iterator.IterateAll(x=>true).Skip(100).Take(100); // LINQ: take items 101..200
		foreach(var x in lst){ Console.WriteLine(x); } // output list
