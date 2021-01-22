    public void PrintValues(int? a = null, int? b = null, float? c = null, string s = "")
	{
		if(a.HasValue)
			Debug.Log(a);
		else
			Debug.Log("-");
		if(b.HasValue)
			Debug.Log(b);
		else
			Debug.Log("-");
		if(c.HasValue)
			Debug.Log(c);
		else
			Debug.Log("-");
    
        if(s != "") // Different check for strings
			Debug.Log(s);
		else
			Debug.Log("-");
	}
    
