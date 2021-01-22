public abstract class SimpleCacheItem&lt;T, TKey> : IDisposable where T : class
{
	private readonly SimpleCache&lt;T, TKey> _cache;
	protected SimpleCacheItem(TKey id, SimpleCache&lt;T, TKey> cache)
	{
		Id = id;
		_cache = cache;
	}
	protected TKey Id { get; private set; }
	#region IDisposable Members
	public virtual void Dispose()
	{
		if (_cache == null) return;
		_cache.ReleaseLock(Id);
	}
	#endregion
	protected bool AcquireLock(int timeout)
	{
		return _cache.AcquireLock(Id, -1);
	}
}
public abstract class SimpleCache&lt;T, TKey> where T : class
{
	private static readonly object CacheItemLockSyncLock = new object();
	private static readonly object CacheItemStoreSyncLock = new object();
	private readonly Dictionary&lt;TKey, int> _cacheItemLock;
	private readonly Dictionary&lt;TKey, T> _cacheItemStore;
	public abstract T CreateItem(TKey id, SimpleCache&lt;T, TKey> cache);
	public T GetCachedItem(TKey id)
	{
		T item;
		lock (CacheItemStoreSyncLock)
		{
			if (!_cacheItemStore.TryGetValue(id, out item))
			{
				item = CreateItem(id, this);
				_cacheItemStore.Add(id, item);
			}
		}
		return item;
	}
	public void ReleaseLock(TKey id)
	{
		lock (CacheItemLockSyncLock)
		{
			if (_cacheItemLock.ContainsKey(id))
			{
				_cacheItemLock.Remove(id);
			}
		}
#if DEBUG
		Trace.WriteLine(string.Format("Thread id: {0} lock released", 
		Thread.CurrentThread.ManagedThreadId));
#endif
	}
	public bool AcquireLock(TKey id, int timeOut)
	{
		var timer = new Stopwatch();
		timer.Start();
		while (timeOut &lt; 0 || timeOut &lt; timer.ElapsedMilliseconds)
		{
			lock (CacheItemLockSyncLock)
			{
				int threadId;
				if (!_cacheItemLock.TryGetValue(id, out threadId))
				{
					_cacheItemLock.Add(id, 
						Thread.CurrentThread.ManagedThreadId);
#if DEBUG
					Trace.WriteLine(string.Format(
						"Thread id: {0}, lock acquired after {1} ms", 
						Thread.CurrentThread.ManagedThreadId, 
						timer.ElapsedMilliseconds));
#endif
					return true;
				}
				if (threadId == Thread.CurrentThread.ManagedThreadId) 
					return true;
			}
			Thread.Sleep(15);
		}
		return false;
	}
}
