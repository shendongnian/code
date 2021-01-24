    public class UnorderedKeyComparer : IEqualityComparer<Key>
	{
		public bool Equals(Key x, Key y)
		{
			if (object.ReferenceEquals(x, y))
				return true;
			if (x == null || y == null)
				return false;
			if (string.Equals(x.NameA, y.NameA) && string.Equals(x.NameB, y.NameB))
				return true;
			if (string.Equals(x.NameA, y.NameB) && string.Equals(x.NameB, y.NameA))
				return true;
			return false;
		}
		public int GetHashCode(Key obj)
		{
			return (obj?.NameA?.GetHashCode() ?? int.MinValue) ^ (obj?.NameB?.GetHashCode() ?? int.MinValue);
		}
	}
