    var persons =
        from c in db.Credits
        join p in db.People on c.PersonId equals p.Id
        where c.PersonId == personId
        group c by new { id = c.PersonId, name = p.Name }
        into g
        select new
        {
            name = g.Key.name,
            credits = from cr in g
                join m in db.Movies on cr.MovieId equals m.Id
                group cr by new { id = cr.MovieId, year = m.Year, title = m.Title }
                into g2
                orderby g2.Key.year
                select new
                    {
                        title = g2.Key.title,
                        roles = g2.Select(ci =>
                                          (ci.Role == "A") ? "actor" : "director")
                    }
        };
