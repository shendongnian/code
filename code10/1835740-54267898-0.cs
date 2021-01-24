    List<Entity> list = new DomainModelDbContext().books.ToList();
    
    foreach (var l in list)
    {
        list.Add(l); // Runtime error
    }
