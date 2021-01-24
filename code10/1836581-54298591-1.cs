    // benchmark example
    var enumerable = Enumerable.Repeat(1, 1000000);
    var collection = enumerable.ToList();
		
	Stopwatch st = Stopwatch.StartNew();
	List<int> copy1 = new List<int>(enumerable);
	Console.WriteLine(st.ElapsedMilliseconds);
		
	st = Stopwatch.StartNew();
	List<int> copy2 = new List<int>(collection);
	Console.WriteLine(st.ElapsedMilliseconds);
