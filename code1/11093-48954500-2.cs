    private static List<int> quickie2(List<int> ites)
    {
        if (ites.Count <= 1)
            return ites;
        var piv = ites[0];
        List<int> les = new List<int>();
        List<int> sam = new List<int>();
        List<int> mor = new List<int>();
        Enumerable.Range(0, 3).AsParallel().ForAll(i =>
        {
            switch (i)
            {
                case 0: les = (from _item in ites where _item < piv select _item).ToList(); break;
                case 1: sam = (from _item in ites where _item == piv select _item).ToList(); break;
                case 2: mor = (from _item in ites where _item > piv select _item).ToList(); break;
            }
        });
        List<int> allofem = new List<int>();
        var _les = new List<int>();
        var _mor = new List<int>();
        ConcurrentBag<ManualResetEvent> finishes = new ConcurrentBag<ManualResetEvent>();
        for (int i = 0; i < 2; i++)
        {
            var fin = new ManualResetEvent(false);
            finishes.Add(fin);
            (new Thread(new ThreadStart(() =>
            {
                if (i == 0)
                    _les = quickie(les);
                else if (i == 1)
                    _mor = quickie(mor);
                fin.Set();
            }))).Start();
        }
        finishes.ToList().ForEach(k => k.WaitOne());
        allofem.AddRange(_les);
        allofem.AddRange(sam);
        allofem.AddRange(_mor);
        return allofem;
    }
