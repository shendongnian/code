    // create a list to test with
    var theList = Enumerable.Range(0, 100000000).ToList();
    
    // time foreach
    var sw = Stopwatch.StartNew();
    foreach (var item in theList)
    {
    	int inLoop = item;
    }
    Console.WriteLine("list  foreach: " + sw.Elapsed.ToString());
    
    sw.Reset();
    sw.Start();
    
    // time for
    int cnt = theList.Count;
    for (int i = 0; i < cnt; i++)
    {
    	int inLoop = theList[i];
    }
    Console.WriteLine("list  for    : " + sw.Elapsed.ToString());
    
    // now run the same tests, but with an array
    var theArray = theList.ToArray();
    
    sw.Reset();
    sw.Start();
    
    foreach (var item in theArray)
    {
    	int inLoop = item;
    }
    Console.WriteLine("array foreach: " + sw.Elapsed.ToString());
    
    sw.Reset();
    sw.Start();
    
    // time for
    cnt = theArray.Length;
    for (int i = 0; i < cnt; i++)
    {
    	int inLoop = theArray[i];
    }
    Console.WriteLine("array for    : " + sw.Elapsed.ToString());
    
    Console.ReadKey();
