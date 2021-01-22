    public DateTime dateForSp(string s)
    {
        string[] sd = s.Split('/');
        string[] yd = sd[2].Split(' ');
        string[] hd = yd[1].Split(':');
        DateTime dt = new DateTime(Int32.Parse(yd[0]),
                                   Int32.Parse(sd[0]),
                                   Int32.Parse(sd[1]),
                                   Int32.Parse(hd[0]),
                                   Int32.Parse(hd[1]),
                                   Int32.Parse(hd[2]));
        return dt;
    }
