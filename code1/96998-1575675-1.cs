	class ReferenceComparer : IEqualityComparer<object>
	{
		bool IEqualityComparer<object>.Equals(object x, object y)
		{ return Object.ReferenceEquals(x, y); }
		int IEqualityComparer<object>.GetHashCode(object obj)
		{ return RuntimeHelpers.GetHashCode(obj); }
	}
