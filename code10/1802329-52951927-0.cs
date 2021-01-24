    var seq = "hello  ️‍️ world".Codepoints();
	foreach(var cp in seq)
	{
		if(cp.AsUtf32 < 127) 
		{
			sb.Append(cp.AsString());
		}
		else
		{
			sb.Append(cp.ToString().Replace("U+", "") + " ");
		}
	}
	sb.ToString().Dump();
