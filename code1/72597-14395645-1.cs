        List<List<int>> l = new List<List<int>>();
        List<int> a = new List<int>();
        a.Add(1);
        a.Add(2);
        a.Add(3);
        a.Add(4);
        a.Add(5);
        a.Add(6);
        List<int> b = new List<int>();
        b.Add(11);
        b.Add(12);
        b.Add(13);
        b.Add(14);
        b.Add(15);
        b.Add(16);
        l.Add(a);
        l.Add(b);
        var r = l.SelectMany(d => d).ToList();
        foreach(int i in r)
        {
            Console.WriteLine(i);
        }
