	class ObjectPoolReference<T> : IDisposable
	{
		public ObjectPool<T> Pool { get; private set; }
		public T Instance { get; private set; }
		public ObjectPoolReference(ObjectPool<T> pool, T instance)
		{
			Pool = pool;
			Instance = instance;
		}
		~ObjectPoolReference()
		{
			Dispose();
		}
		#region IDisposable Members
		private bool _Disposed = false;
		public void Dispose()
		{
			if (!_Disposed)
			{
				Pool.PutObject(Instance);
				_Disposed = true;
			}
		}
		#endregion
	}
    //instance of the pool
    ObjectPool<Foo> Pool;
    
    //"using" ensures the reference is disposed at the end of the block, releasing the object back to the pool
    using (var Ref = Pool.GetObject())
    {
    	Ref.Instance.DoSomething();
    }
