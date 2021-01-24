	class ConstantHasCode: IEquatable<ConstantHasCode>
	{
		public int SomeVariable;
		public virtual Equals(ConstantHasCode other)
		{
			return other.SomeVariable == SomeVariable;
		}
		
		public override int GetHashCode()
		{
			return 0;
		}
	}
