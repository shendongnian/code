	public static void ProcessHT(Hashtable ht)
	{
		Hashtable dates = new Hashtable();
		
		foreach(DictionaryEntry de in ht)
		{
			if (de.Value is DateTime)
				dates.Add(de.Key, de.Value);
		}
		
		foreach(DictionaryEntry de in dates)
		{
			ht.Remove(de.Key);
			ht.Add(de.Key, ((DateTime)de.Value).ToString("s"));
		}
	}
	
	public static void RunSnippet()
	{
		Hashtable ht = new Hashtable();
		
		ht.Add("1", "one");
		ht.Add("date", DateTime.Today);
		ht.Add("num", 1);
		Print(ht);
		WL("---");
		ProcessHT(ht);
		Print(ht);
	}
	
	private static void Print(Hashtable ht)
	{
		foreach (DictionaryEntry de in ht)
		{
			WL("{0} = {1}", de.Key, de.Value);
		}
	}
