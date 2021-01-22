		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			var vector = obj as IVector<T>;
			return (EqualsInternal(vector));
		}
		public bool Equals(IVector<T> other)
		{
			return other != null && EqualsInternal(other);
		}
		private bool EqualsInternal(IVector<T> other)
		{
			if (dimensionCount != other.DimensionCount)
			{
				return false;
			}
			for (var i = 0; i < dimensionCount; i++)
			{
				if (!Equals(this[i], other[i]))
				{
					return false;
				}
			}
			return true;
		}
		public static bool operator ==(VectorBase<T> left, IVector<T> right)
		{
			// If both are null, or both are same instance, return true.
			if (ReferenceEquals(left, right))
			{
				return true;
			}
			// If one is null, but not both, return <c>false</c>.
			if (((object)left == null) || (right == null))
			{
				return false;
			}
			// Return true if the fields match:
			return left.EqualsInternal(right);
		}
		public static bool operator !=(VectorBase<T> left, IVector<T> right)
		{
			return !(left == right);
		}
		/// <inheritdoc />
		public override int GetHashCode()
		{
			var hashCode = 0;
			for (var index = 0; index < dimensionCount; index++)
			{
				hashCode ^= this[index].GetHashCode();
			}
			return hashCode;
		}
