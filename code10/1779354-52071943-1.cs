	using (var driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "neo")))
	{
		using (var session = driver.Session())
		{
			using (var tx = session.BeginTransaction())
			{
				IStatementResult results = tx.Run(
				@"MATCH (m:Movie)<-[r:HAS_WATCHED_MOVIE]-(b) 
				  RETURN m, COUNT(r)
				  ORDER BY COUNT(r) DESC
				  LIMIT 3");
				foreach (IRecord result in results)
				{
					var node = result["m"].As<INode>();
					var title = node.Properties["title"]?.As<string>();
					var count = result["COUNT(r)"].As<long>();
                    var movie = new Movie {
                          Title = title,
                    };
					Console.WriteLine($"'{movie.Title}' had {count} watchers");
				}
			}
		}
	}
