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
                group ((ci.Role == "A") ? "actor" : "director") by m into g2
                orderby g2.Key.year
                select new { title = g2.Key.Title, roles = g2 }
        };
