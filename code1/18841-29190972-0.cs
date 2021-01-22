    Dictionary<string, string> t1 = new Dictionary<string, string>();
    t1.Add("a", "aaa");
    Dictionary<string, string> t2 = new Dictionary<string, string>();
    t2.Add("b", "bee");
    Dictionary<string, string> t3 = new Dictionary<string, string>();
    t3.Add("c", "cee");
    t3.Add("d", "dee");
    t3.Add("b", "bee");
    Dictionary<string, string> merged = t1.MergeLeft(t2, t2, t3);
