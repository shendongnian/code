	var data = new Dictionary<string, string> {
		{ "Hello", "World" },
		{ "How are", "You?" },
		{ "Goodbye", "World!" }
	};
	var results = new List<KeyValuePair<string, string>>();
	var pending = 0;
	var done = new ManualResetEvent(false);
	var workers = new List<Action>();
	foreach (var pair in data)
	{
		++pending;
		var copy = pair; // define a different variable for each worker
		workers.Add(delegate()
		{
			Console.WriteLine("Item {0}, {1}", copy.Key, copy.Value);
			lock (results)
				results.Add(new KeyValuePair<string, string>("New " + copy.Key, "New " + copy.Value));
			if (0 == Interlocked.Decrement(ref pending))
				done.Set();
		});
	}
	foreach (var worker in workers)
		worker.BeginInvoke(null, null);
	done.WaitOne();
	foreach (var pair in results)
		Console.WriteLine("Result {0}, {1}", pair.Key, pair.Value);
