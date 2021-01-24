	static void Main(string[] args)
    {
	    var d1 = new Dictionary<int, object>();
		var d2 = new Dictionary<Type, object>();   
		var counter = 0;
		var types = Assembly.GetAssembly(typeof(int)).GetTypes();
        foreach (var t in types)
	    {
			d1.Add(counter++, null);
			d2.Add(t, null);
		}
		//warmup run. JITTER
		benchMarkDictionary(d1, i => i);
		//good runs
		for (var repetition = 0; repetition < 10; repetition++)
		{
			Console.WriteLine($"Test #{repetition} --------");
			Console.WriteLine($"int key: {benchMarkDictionary(d1, i => i)}");
			Console.WriteLine($"type key: {benchMarkDictionary(d2, i => types[i])}");
		}
	}
        
    static long benchMarkDictionary<TKey, TValue>(
		Dictionary<TKey, TValue> dict,
		Func<int, TKey> keyRandomGenerator)
	{
		var count = dict.Count;
		TValue result = default(TValue);
		var watch = new Stopwatch();
		watch.Start();
		for (var lookups = 0; lookups < count * 1000; lookups++)
		{
			TKey key = keyRandomGenerator(lookups % count);
			result = dict[key];
		}
		watch.Stop();
		Console.WriteLine(result);
		return watch.ElapsedMilliseconds;
	}
 
