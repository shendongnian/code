    var persons =
        from c in db.Credits
        where c.PersonId == arg
        group c by c.People into g
        select new
        {
            name = g.Key.Name,
            credits = from cr in g
                group ((cr.Role == "A") ? "actor" : "director")
                by cr.Movies into g2
                orderby g2.Key.Year
                select new { title = g2.Key.Title, roles = g2 }
        };
