    public sealed class Singleton
	{
		private static WeakReference<Singleton> weakInstance;
		public WeakReference<Singleton> Instance
		{
			get
			{
				if (weakInstance == null)
					weakInstance = new WeakReference<Singleton>(this);
				else
					weakInstance.SetTarget(this);
				return weakInstance;
			}
		}
	}
