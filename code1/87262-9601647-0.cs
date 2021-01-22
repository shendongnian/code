	public static IEnumerable<string> Partition(this string str, int size)
	{
		return str.Partition<char>(size).Select(AsString);
	}
	public static string AsString(this IEnumerable<char> charList)
	{
		return new string(charList.ToArray());
	}
