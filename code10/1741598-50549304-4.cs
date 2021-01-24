	public static class ThreadSafeRandom
	{
		private static Random rnd = new Random();
		private static object _lockObject = new object();
		[ThreadStatic]
		private static Random _random = null;
		public static Random Random
		{
			get
			{
				if (_random == null)
				{
					int seed = 0;
					lock (_lockObject)
					{
						seed = rnd.Next(0, int.MaxValue);
					}
					_random = new Random(seed);
				}
				return _random;
			}
		}
	}
	public static int PerformAddition(int value)
	{
		return value + ThreadSafeRandom.Random.Next(0, 100);
	}
