    public string check(string s)
	{
		var res = "";
		if (s.Length>=25)
			res = s.Substring(3,13);
		else if (s.Length <= 13)
			res = s;
		return res;
	}
