    public class RuleConparer : IEqualityComparer<Rule>
	{
		public bool Equals(Rule x, Rule y)
		{
			if (object.ReferenceEquals(x, y)) return true;
			if (x == null || y == null) return false;
			if(!(x.TestId == y.TestId && x.File == y.File)) return false;
			return x.Columns.SequenceEqual(y.Columns);
		}
		public int GetHashCode(Rule obj)
		{
			// ...
		}
	}
