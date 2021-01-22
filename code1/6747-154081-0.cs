	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj))
			throw new NullReferenceException("obj is null");
		if (ReferenceEquals(this, obj)) return true;
		if (obj.GetType() != typeof (Quad<T1, T2, T3, T4>)) return false;
		return Equals((Quad<T1, T2, T3, T4>) obj);
	}
	public bool Equals(Quad<T1, T2, T3, T4> obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		if (ReferenceEquals(this, obj)) return true;
		return Equals(obj.Item1, Item1)
			&& Equals(obj.Item2, Item2)
				&& Equals(obj.Item3, Item3)
					&& Equals(obj.Item4, Item4);
	}
	public override int GetHashCode()
	{
		unchecked
		{
			int result = Item1.GetHashCode();
			result = (result*397) ^ Item2.GetHashCode();
			result = (result*397) ^ Item3.GetHashCode();
			result = (result*397) ^ Item4.GetHashCode();
			return result;
		}
	}
	public static bool operator ==(Quad<T1, T2, T3, T4> left, Quad<T1, T2, T3, T4> right)
	{
		return Equals(left, right);
	}
	public static bool operator !=(Quad<T1, T2, T3, T4> left, Quad<T1, T2, T3, T4> right)
	{
		return !Equals(left, right);
	}
