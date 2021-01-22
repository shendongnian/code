	public string DoMagic(string s)
	{
		string t = s.Substring(s.LastIndexOf(' ')+1);
		return t.Substring(0, t.Length-1) + (int.Parse(t[t.Length-1].ToString())+1).ToString();
	}
