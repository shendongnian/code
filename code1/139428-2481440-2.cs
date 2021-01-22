      int personId = 10007;
      var persons = db.People.Where( p => p.Id == personId );
      var movies = db.Movies
                     .Join( db.Credits.Where( c => c.PersonId == personId),
                            m => m.Id,
                            c => c.MovieId,
                           (m,c) => new {
                       personid = c.PersonId,
                       title = m.title,
                       role = c.Role == "D" : "director", "actor"
                      })
                     .GroupBy( g => new { g.personid, g.title } )
                     .ToList()
                     .Select( g => new {
                         personid = g.Key.personid,
                         title = g.Key.title
                         roles = string.Join( ",", g.Select( g => g.role ).ToArray() )
                      });
                 
      var personsWithMovies = people.Join( movies, p => p.PersonId, m => m.personid, (p,m) => new {
                                name = p.Name,
                                movies = m 
                              });
