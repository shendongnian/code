	private class GroupKeys
	{
		public string Key1 { get; set; }
		public string Key2 { get; set; }
		public override int GetHashCode()
		{
			unchecked
			{
				return ((Key1 != null ? Key1.GetHashCode() : 0) * 397) ^ (Key2 != null ? Key2.GetHashCode() : 0);
			}
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((GroupKeys)obj);
		}
		public bool Equals(GroupKeys other)
		{
			if (ReferenceEquals(null, other))
				return false;
			if (ReferenceEquals(this, other))
				return true;
			return string.Equals(Key1, other.Key1)
				   && string.Equals(Key2, other.Key2);
		}
	}
