	public class CompositeValueTupleComparer<T1, T2> : IEqualityComparer<(T1, T2)>
	{
		private static readonly EqualityComparer<T1> t1Comparer = EqualityComparer<T1>.Default;
		private static readonly EqualityComparer<T2> t2Comparer = EqualityComparer<T2>.Default;
		
		public bool Equals((T1, T2) x, (T1, T2) y) => 
            t1Comparer.Equals(x.Item1, y.Item1) || t2Comparer.Equals(x.Item2, y.Item2);
	
		public int GetHashCode((T1, T2) obj) => obj.Item1.GetHashCode();
	}
    new Dictionary<(int, string), Book>(new CompositeValueTupleComparer<int, string>());
