    struct myStruct
    {
        public Dictionary<string, int> a;
        public Dictionary<string, string> b;
    }
    IList<myStruct> l = new List<myStruct>();
    myStruct s;
    s.a = new Dictionary<string, int>();
    s.b = new Dictionary<string, string>();
    s.a.Add("id", 1);
    s.b.Add("name","Tim");
    l.Add(s);
