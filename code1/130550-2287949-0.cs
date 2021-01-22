    class A
	{
		public int Id;
		public int? ParentId;
		public string Name;
		public static Func<T1, T2> Fix<T1, T2>(Func<Func<T1, T2>, Func<T1, T2>> f)
		{
			return f(x => Fix(f)(x));
		}
		public static string[] GetPaths(A[] array)
		{
			return array.Select(
				Fix<A, string>(self => x => x.ParentId != null ? self(array.First(a => a.Id == x.ParentId.Value)) + "\\" + x.Name : x.Name)
				).ToArray();
		}
	}
