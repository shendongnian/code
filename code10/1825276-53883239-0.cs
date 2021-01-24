    int Id = 1;
    IEnumerable<YourClassName> permission = null;
    if(Id != 0) {
        permission = from x in db.foo
            join y in db.bar
            on x.Id equal y.fkBar
            select new YourClassName {
                Id = x.Id,
                Name = y.Name }
    } else {
        permission = from x in db.foo
            select new YourClassName {
                Id = x.Id,
                Name = "" }
    }
    
    return permission;
