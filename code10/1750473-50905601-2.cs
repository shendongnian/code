    var result = collection
        .Aggregate()
        .Match(c => c.CustomerId == 2)
        .Project(c => new
            {
                c.CustomerId,
                Addresses = c.Addresses.Where(a => a.Name.IndexOf(searchTerm) != -1)
            })
        .ToList();
