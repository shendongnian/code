    public static object[] ProcessLine(string line)
    {
    	object[] obj = null;
    	var m = rx.Match(line);
        if (m.Success)
       	{
           	obj = new object[] {
           		m.Groups[1].Value,
           		m.Groups[2].Value,
           		m.Groups[3].Value,
           		int.Parse(m.Groups[4].Value).ToString(),
           		m.Groups[5].Value,
           		m.Groups[6].Value,
           		m.Groups[7].Value
   		    };
        }
        return obj;
    }
