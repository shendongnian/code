	public class Repository
	{
		private Dictionary<Type, Dictionary<string, object>> _store
			= new Dictionary<Type, Dictionary<string, object>>();
		
		public void Store<T>(string key, T value)
		{
			if (!_store.ContainsKey(typeof(T)))
			{
				_store.Add(typeof(T), new Dictionary<string, object>());
			}
			_store[typeof(T)][key] = value;
		}
		
		public T Fetch<T>(string key)
		{
			return (T)_store[typeof(T)][key];
		}
		
		public bool TryFetch<T>(string key, out T value)
		{
			var success = _store.ContainsKey(typeof(T)) && _store[typeof(T)].ContainsKey(key);
			value = success ? this.Fetch<T>(key) : default(T);
			return success;
		}
		
		public bool TryInject<T>(string key, Action<T> inject)
		{
			var success = this.TryFetch<T>(key, out T value);
			if (success)
			{
				inject(value);
			}
			return success;
		}		
	}
