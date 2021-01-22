		static void Main(string[] args)
		{
			List<string[]> data1 = new List<string[]>();
			List<string[]> data2 = new List<string[]>();
			var result = data1.Intersect(data2, new Comparer());
		}
		class Comparer : IEqualityComparer<string[]>
		{
			#region IEqualityComparer<string[]> Members
			bool IEqualityComparer<string[]>.Equals(string[] x, string[] y)
			{
				return x[0] == y[0];
			}
			int IEqualityComparer<string[]>.GetHashCode(string[] obj)
			{
				return obj.GetHashCode();
			}
			#endregion
		}
