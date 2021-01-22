    List<int> a = new List<int> {1, 2, 3, 4, 5};
    IList<int> b = a.AsReadOnly(); // block modification...
    IList<int> c = b.AsWritable(); // ... but unblock it again
    c.Add(6);
    Debug.Assert(a.Count == 6); // we've modified the original
    IEnumerable<int> d = a.Select(x => x); // okay, try this...
    IList<int> e = d.AsWritable(); // no, can still get round it
    e.Add(7);
    Debug.Assert(a.Count == 7); // modified original again
