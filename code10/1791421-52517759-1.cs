    var sourceList = new List<MyObject>();
    // let's mock the source data, every 27th element will be null
    for (int i = 0; i < 2500000; ++i)
    {
        if (i % 27 != 0)
            sourceList.Add(new MyObject { Id = i, Flag = (i % 2 == 0) });
    }
    var destArray = new MyObject[2500000];
    Stopwatch sw = new Stopwatch();
    sw.Start();
    Console.WriteLine(sw.ElapsedMilliseconds);
    var currentElement = 0;
    for (int i = 0; i < sourceList.Count; ++i)
    {
        MyObject entityCloned = MyObject.GetEntityClone(sourceList[i]);
        if (entityCloned != null)
            destArray[currentElement++] = entityCloned;
    }
    var result = new MyObject[currentElement];
    Array.Copy(destArray, 0, result, 0, currentElement);
    sw.Stop();
    Console.WriteLine(sw.ElapsedMilliseconds);
