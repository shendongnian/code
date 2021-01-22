	public IEnumerable<string> SplitX (string text, string[] delimiters)
	{
		var split = text.Split (delimiters, StringSplitOptions.None);
		foreach (string part in split) {
			yield return part;
			text = text.Substring (part.Length);
			string delim = delimiters.FirstOrDefault (x => text.StartsWith (x));
			if (delim != null) {
				yield return delim;
				text = text.Substring (delim.Length);
			}
		}
	}
