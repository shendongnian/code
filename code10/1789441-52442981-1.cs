    public class RuleComparer : IEqualityComparer<Rule>
	{
		public bool Equals(Rule x, Rule y)
		{
			if (object.ReferenceEquals(x, y)) return true;
			if (x == null || y == null) return false;
			if(!(x.TestId == y.TestId && x.File == y.File)) return false;
			return x.Columns.SequenceEqual(y.Columns);
		}
        // from: https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
		public int GetHashCode(Rule obj)
		{
			unchecked
			{
				int hash = 17;
				hash = hash * 23 + obj.TestId.GetHashCode();
				hash = hash * 23 + (obj.File?.GetHashCode() ?? 0);
				foreach(string s in obj.Columns)
					hash = hash * 23 + (s?.GetHashCode() ?? 0);
				return hash;
			}
		}
	}
