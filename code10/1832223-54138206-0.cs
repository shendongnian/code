	public class CuratedIncludeUid
	{
		public string type { get; set; }
		public string uid { get; set; }
		protected bool Equals(CuratedIncludeUid other)
		{
			return string.Equals(type, other.type) && string.Equals(uid, other.uid);
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return Equals((CuratedIncludeUid) obj);
		}
		public override int GetHashCode()
		{
			unchecked
			{
				return ((type != null ? type.GetHashCode() : 0) * 397) ^ (uid != null ? uid.GetHashCode() : 0);
			}
		}
	}
