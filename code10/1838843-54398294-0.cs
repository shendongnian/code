	public override Func<IEnumerable<IOhlcv>, int, IIndexedOhlcv> IndexedObjectConstructor
	{
		get
		{
			return (xs, i) => Test(xs, i);
		}
	}
