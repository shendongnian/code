public static string CommaQuibbling(IEnumerable<string> items)
{
	StringBuilder sb = new StringBuilder("{");
	bool empty = true;
	string prev = null;
	foreach (string s in items)
	{
		if (prev!=null)
		{
			if (!empty) sb.Append(", ");
			else empty = false;
			sb.Append(prev);
		}
		prev = s;
	}
	if (prev!=null)
	{
		if (!empty) sb.Append(" and ");
		sb.Append(prev);
	}
	return sb.Append('}').ToString();
}
