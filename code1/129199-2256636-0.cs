	public void LinqExample()
	{
		string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
		var sortedWords = words.OrderByDescending(a => a, new CaseInsensitiveComparer());
		ObjectDumper.Write(sortedWords);
	}
	public class CaseInsensitiveComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
		}
	}
