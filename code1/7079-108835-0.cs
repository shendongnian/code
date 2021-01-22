    List<string> stringlist = new List<string>();
    
    // add your values to stringlist
    
    Random r = new Random();
    
    List<string> res = new List<string>();
    
    while (stringlist.Length >0)
    {
       int i = r.GetNext(stringlist.Length);
       res.Add(stringlist[i]);
       stringlist.RemoveAt(i);
    }
