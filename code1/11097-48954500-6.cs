	public static IEnumerable<int> QSLinq3(IEnumerable<int> _items)
	{
		if (_items.Count() <= 1)
			return _items;
		var _pivot = _items.First();
		IEnumerable<int> _less = null;
		IEnumerable<int> _same = null;
		IEnumerable<int> _greater = null;
		ConcurrentBag<ManualResetEvent> finishes = new ConcurrentBag<ManualResetEvent>();
		Enumerable.Range(0, 3).AsParallel().ForAll(i =>
		{
			var fin = new ManualResetEvent(false);
			finishes.Add(fin);
			(new Thread(new ThreadStart(() =>
			{
				if (i == 0)
					_less = from _item in _items where _item < _pivot select _item;
				else if (i == 1)
					_same = from _item in _items where _item == _pivot select _item;
				else if (i == 2)
					_greater = from _item in _items where _item > _pivot select _item;
				fin.Set();
			}))).Start();
		});
		finishes.ToList().ForEach(k => k.WaitOne());
		return QSLinq(_less).Concat(_same).Concat(QSLinq(_greater));
	}
