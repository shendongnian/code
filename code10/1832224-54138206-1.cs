	public class CuratedIncludeUidEqualityComparer : IEqualityComparer<CuratedIncludeUid>
	{
		public bool Equals(CuratedIncludeUid x, CuratedIncludeUid y)
		{
			if (ReferenceEquals(x, y)) return true;
			return string.Equals(x?.type, y?.type) && string.Equals(x?.uid, y?.uid);
		}
		public int GetHashCode(CuratedIncludeUid obj)
		{
			unchecked
			{
				return ((obj.type != null ? obj.type.GetHashCode() : 0) * 397) ^ (obj.uid != null ? obj.uid.GetHashCode() : 0);
			}
		}
	}
