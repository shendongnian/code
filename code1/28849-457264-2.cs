    foreach (var item in itemlist)
    {
        var dlist = item.examples.Select(ex => ex.GetDummy()).ToList();
        p.AddStuff(item.X,item.Y,dlist);
    }
    
