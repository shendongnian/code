    Note[] SomeFunc(...) {
        using(var ctx = ...) {
            return (from row in ctx.SomeSP(...) // row is the dbml type
                 select new Note { // Note is our custom type
                     Id = row.Id,
                     Name = row.Name,
                     // etc
                  }).ToArray(); // or whatever
        }
    }
