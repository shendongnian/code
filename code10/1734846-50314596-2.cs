    var aList = aEven.Zip(aOdd, (even, odd) => new {even, odd})
    				 .Aggregate(new List<int>(aEven.Length + aOdd.Length),
    							(list, z) =>
    							{
    								list.Add(z.even);
    								list.Add(z.odd);
    								return list;
    							});
    if (aEven.Length != aOdd.Length)
    	aList.Add(aEven[aEven.Length-1]);
    
    var aOutput = aList.ToArray();
    
    for (var i = 0; i < aOutput.Length; ++i)
    	Console.WriteLine($"aOutput[{i}] ==> {aOutput[i]} == {a[i]} <== a[{i}]");
