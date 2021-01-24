	void Main()
	{
		var gc = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "neo");
		gc.Connect();
		
		var batches = GetBatches(GenerateMyClass(), 5000);
		var now = DateTime.Now;
		foreach (var batch in batches)
		{
			DateTime bstart = DateTime.Now;
			var query = gc.Cypher
				.Unwind(batch, "node")
				.Merge($"(n:{nameof(MyClass)} {{Id: node.Id}})")
				.Set("n = node")
				.With("n, node")
				.Unwind("node.LinkToIds", "linkTo")
				.Merge($"(n1:{nameof(MyClass)} {{Id: linkTo}})")
				.With("n, n1")
				.Merge("(n)-[:LINKED_TO]->(n1)");
			query.ExecuteWithoutResults();
			Console.WriteLine($"Batch took: {(DateTime.Now - bstart).TotalMilliseconds} ms");
		}
		Console.WriteLine($"Total took: {(DateTime.Now - now).TotalMilliseconds} ms");
	}
