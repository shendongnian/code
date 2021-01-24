    var results = nList.GroupBy(x=>x._Issue);
    
    Console.WriteLine("Group By _Issue");
    foreach(var item in results)
    {
    	Console.WriteLine(item.Key);
    	var IpString = string.Join("  ",item.ToList().Select(x=> $"{x._HostIp} {x._ProtoPort}"));
    	Console.WriteLine(IpString);
    	Console.WriteLine();
    }
