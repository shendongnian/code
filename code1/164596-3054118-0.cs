	...
	for (int i=0; i<lines.Count; i++)
	{
		sb.Append("[" + lines[i] + "]");
		if (i < lines.Count - 1)
			sb.Append(", ");
	}
	if (sb.Length != 0)
	{
		sb.Insert(0, ">>> ");
		sb.Append(" >>>");
	}
