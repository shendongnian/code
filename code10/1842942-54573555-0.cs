    string a = "abc";
	string b = "defxyz";
	StringBuilder sb = new StringBuilder();
	int max = Math.Max(a.Length, b.Length);
	for (int i = 0; i < max; i++)
	{
		if (i < a.Length)
		{
			sb.Append(a[i]);
		}
		if (i < b.Length)
		{
			sb.Append(b[i]);
		}
	}
	Console.WriteLine(sb.ToString());
