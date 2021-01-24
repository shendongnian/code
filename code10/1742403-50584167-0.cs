    public class UnorderedFacelineComparer : IEqualityComparer<FaceLine>
	{
		public bool Equals(FaceLine x, FaceLine y)
		{
			int x1 = Math.Min(x.A, x.B);
			int x2 = Math.Max(x.A, x.B);
			int y1 = Math.Min(y.A, y.B);
			int y2 = Math.Max(y.A, y.B);
			return x1 == y1 && x2 == y2;
		}
		public int GetHashCode(FaceLine obj)
		{
			return obj.A ^ obj.B;
		}
	}
