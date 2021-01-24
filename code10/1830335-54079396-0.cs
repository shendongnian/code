			var ids = new Dictionary<int, int>();
			foreach (var id in Ids1)
			{
				int val;
				if (!ids.TryGetValue(id, out val))
				{
					ids.Add(id, ids.Count());
				}
			};
			.
			.
			
			
			
