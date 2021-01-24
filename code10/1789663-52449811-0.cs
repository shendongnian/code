    string tb1 = @"abc:123:def
    abc:741:def2
    xxx:345:bla3";
    string tb2 = @"123:bla
    345:bla2";
    string tb3="";
    
    var repDic = new Dictionary<string,string>();
    foreach(var line in tb2.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries))
    {
    	var spl = line.Split(':');
    	if(!repDic.ContainsKey(spl[0]))
    	{
    		repDic.Add(spl[0],spl[1]);
    	}
    }
    
    StringBuilder sb = new StringBuilder();
    foreach(var line in tb1.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries))
    {
    	var spl = line.Split(':');
    	string val;
    	if(repDic.TryGetValue(spl[1],out val))
    	{
    		sb.AppendLine($"{spl[0]}:{val}:{spl[2]}");
    	}
    	
    }
    tb3 = sb.ToString();
