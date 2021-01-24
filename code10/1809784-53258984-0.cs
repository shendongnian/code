    string name = "";
    int? id = null;
    List<Subscriptions> subs = new List<Subscriptions>();
    var query = subs.AsQueryable();
    if (!string.IsNullOrEmpty(name))
        query = query.Where(p => p.Name == name);
    if(id.HasValue)
        query = query.Where(p => p.id == id.Value);
    var result = query.ToArray();
