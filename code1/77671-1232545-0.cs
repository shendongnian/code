    ...
    IEnumerable<int> f = a.AsReallyReadOnly();
    IList<int> g = f.AsWritable(); // finally can't get around it
    g.Add(8);
    Debug.Assert(a.Count == 78);
