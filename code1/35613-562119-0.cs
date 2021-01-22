    var theClient =
        Repository<Client>
            .Entities()
            .Where(t => t.ShouldBeHere())
            .SingleOrDefault()
            ?? new Client { Name = "Howdy!" }
        ;
