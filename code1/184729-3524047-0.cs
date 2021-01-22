	static class Shared
	{
		private static ReaderWriterLockSlim _rwLock = new ReaderWriterLockSlim();
		private static string[] _values;
		public static string[] Values 
		{
			get
			{
				_rwLock.EnterReadLock();
				try
				{
					return _values;
				}
				finally
				{
					_rwLock.ExitReadLock();
				}
			}
			set
			{
				_rwLock.EnterWriteLock();
				try
				{
					_values = value;
				}
				finally
				{
					_rwLock.ExitWriteLock();
				}
			}
		}
	}
