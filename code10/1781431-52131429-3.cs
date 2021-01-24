    List<List<uint>> AllLists = new List<List<uint>>();
    List<uint> TestList1 = new List<uint>();
    List<uint> TestList2 = new List<uint>();
    List<uint> TestList3 = new List<uint>();
    TestList1.Add(0x18A);
    TestList1.Add(0x188);
    TestList1.Add(0x188);
    TestList1.Add(0x188);
    TestList1.Add(0x188);
    TestList1.Add(0x188);
    TestList1.Add(0x188);
    TestList1.Add(0x670);
    
    TestList2.Add(0x670);
    TestList2.Add(0x670);
    
    TestList3.Clear(); //this one is empty.. but could contain some useless ones (not 0x670).
    AllLists.Add(TestList1.ToList());
    AllLists.Add(TestList2.ToList());
    AllLists.Add(TestList3.ToList());
    
    
    var numbers = AllLists
    	.Select(x => x.GroupBy(y => y).Select(z => new { Key = z.Key }))
    	.SelectMany(x => x)
    	.GroupBy(x => x.Key)
    	.OrderByDescending(x => x.Count())
    	;
    
    var mostCount = numbers.Select(x => x.Count()).Take(1).First();
    
    var numberWithMostCount = numbers
    	.Where(x => x.Count() == mostCount)
    	.Select(x => x.Key)
    	;
    
    foreach (var n in numberWithMostCount)
    	Console.WriteLine(n);
	
