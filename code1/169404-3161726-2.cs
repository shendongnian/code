    struct myStruct
    {
        public IDictionary<string, int> a;
        public IDictionary<string, string> b;
    }
    IList<myStruct> l = new List<myStruct>();
    myStruct s;
    s.a = new Dictionary<string, int>();
    s.b = new Dictionary<string, string>();
    s.a.Add("id", 1);
    s.b.Add("name","Tim");
    l.Add(s);
