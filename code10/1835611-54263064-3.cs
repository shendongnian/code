	static public string GetDelimitedString(this string source, char delimiter, int index)
	{
		var result = source.GetDelimitedField(delimiter, index);
		return new string(result.ToArray());
	}
