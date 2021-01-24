    class name {
            public dynamic p1 { get; set; }
            public dynamic p2 { get; set; }
            public dynamic p3 { get; set; }
        }
        public static void Main(string[] args)
        {
            string code = @"Name1 = {
    p1:0,
    p2:1,
    p3:2
    };
    Name2 = {
    p1:""None"",
    p2: ""Snappy"",
    p3: ""gzip""
    };";
            List<name> l = new List<name>();
            string[] partsBySamicolon = code.Split(';'); 
        
            foreach(string s in partsBySamicolon){
                if (!string.IsNullOrEmpty(s))
                {
                    string[] partByBraces = s.Split('{');
                    name n = new name();
                    string[] partsbyComma = partByBraces[1].Split('}')[0].Split(',');
                    foreach (string ss in partsbyComma)
                    {
                        if (!string.IsNullOrEmpty(ss))
                        {
                            if (ss.Contains("p1"))
                                n.p1 = ss.Split(':')[1].Trim();
                                if (ss.Contains("p2"))
                                n.p2 = ss.Split(':')[1].Trim();
                            if (ss.Contains("p3"))
                                n.p3 = ss.Split(':')[1].Trim();
                        }
                    }
                    l.Add(n);
                }
            }
        
            Console.Read();
        }
