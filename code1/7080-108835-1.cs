    var stringlist = ... // add your values to stringlist
    
    var r = new Random();
    
    var res = new List<string>(stringlist.Count);
    
    while (stringlist.Count >0)
    {
       var i = r.Next(stringlist.Count);
       res.Add(stringlist[i]);
       stringlist.RemoveAt(i);
    }
