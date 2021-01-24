    foreach(var data in c)
    {
        Parent p = new Parent();
        Action<string> iAction = iString =>
        {
            Star s = new Star();
            s.Area = "infinite";
            s.Color = "red";
            List<string> sep = iString.Split(',').Select(string.Parse).ToList();
            foreach(var b in sep)
            {
                TinyStar t = new TinyStar();
                t.smallD = b;
                s.Values.Add(t);
            }
            p.Curves.Add(s);
        }
        if(data.classAObj.count > 0)
        {
            iAction(data.City);
        }
        if(data.classBObj.count > 0)
        {
            iAction(data.Village);
        }
    }
