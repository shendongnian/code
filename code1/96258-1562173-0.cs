	class Object : global::System.Object
	{
		[Obsolete("Do not use ToString()", true)]
		public sealed override string ToString()
		{
			return base.ToString();
		}
		[Obsolete("Do not use Equals(object)", true)]
		public sealed override bool Equals(object obj)
		{
			return base.Equals(this, obj);
		}
		[Obsolete("Do not use GetHashCode()", true)]
		public sealed override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
