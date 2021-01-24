    IList<Sth> sths = Context.Sth
        .Where(g => g.IsX == true && g.Y.Name== "name")
        .Include(g => g.Y)
        .ToList(); 
    this.mylist.AddRange(sths.Select(g => g.Y.Id);
