    private void RunTest()
    {
        ResetData();
        var stopwatch = Stopwatch.StartNew();
        theObjects.ForEach(o => o.selected = idList.Contains(o.id) ? true : false);
        stopwatch.Stop();
        one += stopwatch.ElapsedMilliseconds;
        ResetData();
        stopwatch = Stopwatch.StartNew();
        var results = theObjects.Join(idList, o => o.id, id => id, (o, id) => o).ToList();
        results.ForEach(o => o.selected = true);
        stopwatch.Stop();
        two += stopwatch.ElapsedMilliseconds;
        ResetData();
        stopwatch = Stopwatch.StartNew();
        theObjects
            .Select(o => o.id)
            .Where(i => idList.Contains(i)).ToList()
            .ForEach(i => 
                theObjects.FirstOrDefault(o => o.id == i).selected = true);
        stopwatch.Stop();
        three += stopwatch.ElapsedMilliseconds;
    }
    private void ResetData()
    {
        theObjects = new List<MyObject>();
        idList = new List<int>();
        var rnd = new Random();
        for (var i=0; i<10000; i++) {
            theObjects.Add(new MyObject(){id = i});
        }
        for (var i=0; i<=1000; i++) {
            
            var r = rnd.Next(0, 1000);
            while (idList.Contains(r)) {
                r = rnd.Next(0, 10000);
            }
            idList.Add(r);
        }
    }
