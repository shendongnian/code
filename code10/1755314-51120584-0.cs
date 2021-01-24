	public static class Ex
	{
		public static IEnumerable<(T1, T2)> ZipLongest<T1, T2>(this IEnumerable<T1> t1, IEnumerable<T2> t2)
		{
			var e1 = t1.GetEnumerator();
			var e2 = t2.GetEnumerator();
			var m1 = e1.MoveNext();
			var m2 = e2.MoveNext();
			while (m1 || m2)
			{
				var c1 = m1 ? e1.Current : default(T1);
				var c2 = m2 ? e2.Current : default(T2);
				yield return (c1, c2);
				m1 = m1 && e1.MoveNext();
				m2 = m2 && e2.MoveNext();
			}
		}
	}
