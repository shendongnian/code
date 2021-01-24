    var client = new BoltGraphClient("bolt://localhost:7687", "neo4j", "neo");
    client.Connect();
    
    var query = client.Cypher
                      .Match("(m:Movie)<-[r:HAS_WATCHED_MOVIE]-(b)")
                      .Return((m,r) => new { 
                          Movie = m.As<Movie>(), 
                          Count = r.Count()
                       })
    				  .OrderByDescending("Count")
				      .Limit(3);;
    foreach(var result in query.Results)
       Console.WriteLine($"'{result.Movie.Title}' had {result.Count} watchers");
