	public class NaturalComparer : IComparer
	{
		public NaturalComparer()
		{
			_regex = new Regex("\\d+$", RegexOptions.IgnoreCase);
		}
		private Regex _regex;
		private string matchEvaluator(System.Text.RegularExpressions.Match m)
		{
			return Convert.ToInt32(m.Value).ToString("D10");
		}
		public int Compare(object x, object y)
		{
			x = _regex.Replace(x.ToString, matchEvaluator);
			y = _regex.Replace(y.ToString, matchEvaluator);
			return x.CompareTo(y);
		}
	}	
