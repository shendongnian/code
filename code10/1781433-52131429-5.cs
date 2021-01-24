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
    
    TestList3.Add(0xBADC0DE); //this one is empty.. but could contain some useless ones (not 0x670).
    AllLists.Add(TestList1.ToList());
    AllLists.Add(TestList2.ToList());
    AllLists.Add(TestList3.ToList());
    
    var numbers = AllLists
    	.Select(x => x
    		.GroupBy(y => y)					// group the numbers in each sub-list
    		.Select(z => new { Key = z.Key }))	// select only the key in each sub-list
    	.SelectMany(x => x)						// flatten the lists
    	.GroupBy(x => x.Key)					// group by the keys
    	.OrderByDescending(x => x.Count())		// sort the count of keys from largest to smallest
    	;
    
    var mostCount = numbers
    	.Select(x => x.Count())					// select the count of keys only
    	.Take(1)								// take one, actually this line is not needed. you can remove it
    	.First(); 								// take the largest count of key (the counts were sorted in previous linq statement)
    
    var numberWithMostCount = numbers
    	.Where(x => x.Count() == mostCount)		// filter the largest count of in the lists
    	.Select(x => x.Key)						// select the key only
    	;
    
    foreach (var n in numberWithMostCount)
    	Console.WriteLine(n);					// print all key who has the largest count
	
