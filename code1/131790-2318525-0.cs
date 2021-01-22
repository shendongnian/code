    List<string> list = new List<string>();
    
    list.Add("CS01");
    list.Add("CS02");
    list.Add("CS03");
    list.Add("CS14");
    list.Add("CS11");
    list.Add("CS5");
    list.Add("CS17");
    
    List<string> orderList = list
    	.OrderBy<string, int>(i => int.Parse(i.Replace("CS", string.Empty)))
    	.ToList<string>();
    	
    // Print List
    for (int i = 0; i < orderList.Count; i++)
    {
    	Console.WriteLine(orderList[i]);
    }
