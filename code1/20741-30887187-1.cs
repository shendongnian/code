		// 1. Using IEnumerator allows to get item by item
		var i=Iterator.IterateOne(x=>true); // iterate endless
		// 1.a) get item by item
		i.MoveNext(); Console.WriteLine(i.Current);
		i.MoveNext(); Console.WriteLine(i.Current);
		// 1.b) loop until 100
		int j; while (i.MoveNext() && (j=i.Current)<=100) { Console.WriteLine(j); }
