    var data = Master.Connection.Familys
        .Where(x => some conditions)
        .OrderByDescending(d => d.ID)
        .Select(d => new Families
                       {
                           Id = d.ID,
                           Surname = d.Surname,
                           Address = d.Address,
                           Cars = ""
                       })
        .ToList();
