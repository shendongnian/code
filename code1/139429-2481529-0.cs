    var query =
        from c in context.Credits
        where c.PersonId == 1
        group c by c.Person into g
        select new
        {
            PersonName = g.Key.Name,
            Credits = from cr in g
                      group cr by cr.Movie into g2
                      select new
                      {
                          MovieTitle = g2.Key.Name,
                          Roles = g2.Select(ci =>
                              (ci.Role == 'A') ? "Actor" : "Director")
                      }
        };
