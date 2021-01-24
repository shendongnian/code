    class Initializer
	{
		internal static SemaphoreSlim _semaphoreSlim;
		static SemaphoreSlim Slim
		{
			get
			{
				return LazyInitializer.EnsureInitialized(ref _semaphoreSlim, () => new SemaphoreSlim(1, 1));
			}
		}
		public static void WaitOnAction(Action initializer)
		{
			Initializer.Slim.Wait();
			initializer();
			Initializer.Slim.Release();
		}
	}
