	static void Main(string[] args)
	{
		var d1 = new Dictionary<int, object>();
		var d2 = new Dictionary<Type, object>();
		var keys1 = new List<int>();
		var keys2 = new List<Type>();            
		var counter = 0;
		var types = Assembly.GetAssembly(typeof(int)).GetTypes();
        foreach (var t in types)
		{
			d1.Add(counter, null);
			keys1.Add(counter++);
			d2.Add(t, null);
			keys2.Add(t);
		}
		//warmup run. JITTER
		benchMarkDictionary(d1, keys1);
            
		//good runs
		for (var repetition = 0; repetition < 10; repetition++)
		{
			Console.WriteLine($"Test #{repetition} --------");
			Console.WriteLine($"int key: {benchMarkDictionary(d1, keys1)}");
			Console.WriteLine($"type key: {benchMarkDictionary(d2, keys2)}");
		}
	}
        
    static long benchMarkDictionary<TKey, TValue>(
		Dictionary<TKey, TValue> dict,
		IList<TKey> keys)
	{
		var count = dict.Count;
		TValue result = default(TValue);
		var watch = new Stopwatch();
		watch.Start();
		for (var lookups = 0; lookups < count * 1000; lookups++)
		{
			result = dict[keys[lookups % count]];
		}
		watch.Stop();
		Console.WriteLine(result);
		return watch.ElapsedMilliseconds;
	}
 
