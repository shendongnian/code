	public class TryParser
	{
		public delegate bool TryParseDelegate<T>(string s, out T result);
	
		private Dictionary<Type, Delegate> _tryParsers = new Dictionary<Type, Delegate>();
	
		public void Register<T>(TryParseDelegate<T> d)
		{
			_tryParsers[typeof(T)] = d;
		}
	
		public bool Deregister<T>()
		{
			return _tryParsers.Remove(typeof(T));
		}
	
		public bool TryParse<T>(string s, out T result)
		{
			if (!_tryParsers.ContainsKey(typeof(T)))
			{
				throw new ArgumentException("Does not contain parser for " + typeof(T).FullName + ".");
			}
			var d = (TryParseDelegate<T>)_tryParsers[typeof(T)];
			return d(s, out result);
		}
	}
