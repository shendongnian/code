    class ComponentComparer : IEqualityComparer<Component>
	{
		public bool Equals(Component x, Component y)
		{
			if (object.ReferenceEquals(x, y)) return true;
			if (x == null || y == null) return false;
			return x.Price == y.Price && x.Description == y.Description;
		}
		public int GetHashCode(Component obj)
		{
			unchecked 
			{
				int hash = 17;
				hash = hash * 23 + obj.Price.GetHashCode();
				hash = hash * 23 + obj.Description?.GetHashCode() ?? 0;
				// ...
				return hash;
			}
		}
	}
