	public class MyLazy
	{
		private object	_Value;
		private bool	_Loaded;
		private object	_Lock = new object();
		public MyLazy()
		{
		}
		public void Invalidate()
		{
			lock ( _Lock )
				_Loaded = false;
		}
		public T Get<T>(Func<T> create)
		{
			if ( _Loaded )
				return (T)_Value;
			lock (_Lock)
			{
				if ( _Loaded ) // double checked lock
					return (T)_Value;
				_Value	 = create();
				_Loaded = true;
			}
			return (T)_Value;
		}
	}
