	List<string> items = new List<string>();
	items.Sort(
		delegate(string a, string b)
		{
			if (a[0] == '_' && b[0] == '_')
			{
				return -a.CompareTo(b);
			}
			else if (a[0] == '_')
			{
				return 1;
			}
			else if (b[0] == '_')
			{
				return -1;
			}
			else
			{
				return a.CompareTo(b);
			}
		}
	);
