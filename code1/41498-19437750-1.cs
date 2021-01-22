    public class GenericFuncCollection : IEnumerable<Tuple<Type, Type, Object>>
	{
		private List<Tuple<Type, Type, Object>> objects = new List<Tuple<Type, Type, Object>>();
		/// <summary>
		/// Stores a list of Func of T where T is unknown at compile time.
		/// </summary>
		/// <typeparam name="T1">Type of T</typeparam>
		/// <typeparam name="T2">Type of the Func</typeparam>
		/// <param name="func">Instance of the Func</param>
		public void Add<T1, T2>(Object func)
		{
			objects.Add(new Tuple<Type, Type, Object>(typeof(T1), typeof(T2), func));
		}
		public IEnumerator<Tuple<Type, Type, object>> GetEnumerator()
		{
			return objects.GetEnumerator();
		}
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return objects.GetEnumerator();
		}
	}
