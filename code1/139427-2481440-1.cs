      int personId = 10007;
      var persons =
          (from p in db.People
          where p.Id == personId
          select new
          {
              name   = p.Name,
              movies =
                    (from m in db.Movies
                     join c in db.Credits on m.Id equals c.MovieId
                     where (c.PersonId == personId)
                     select new {
                             title = m.Title,
                             role = (c.Role=="D"?"director":"actor")
                     })
          })
          .ToList()
          .GroupBy( p => new { p.name, title = p.movies.Select( m => m.title ) } )
          .Select( g => new {
               name = g.Key.name,
               title = g.Key.title,
               roles = string.Join( ",", g.movies.Select( m => m.role ).ToArray() )
           });
