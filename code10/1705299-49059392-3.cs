	class ThrowHasCode: IEquatable<ThrowHasCode>
	{
		public int SomeVariable;
		public virtual Equals(ThrowHasCode other)
		{
			return other.SomeVariable == SomeVariable;
		}
		
		public override int GetHashCode()
		{
			throw new ApplicationException("this class does not support GetHashCode and should not be used as a key for a dictionary");
		}
	}
