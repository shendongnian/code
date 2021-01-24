	public async Task GetDocs(string id, Func<Model, bool, Task> processor)
	{
		var filter = Builders<Model>.Filter;
		var sort = Builders<Model>.Sort;
		using (var cursor = await Coll.Find(filter.Eq(f => f.id, id)).ToCursorAsync())
		{
			Model previousDoc = null;
			foreach (var doc in cursor.Current)
			{
				if (previousDoc != null)
				{
					await processor(previousDoc, false);
				}
				previousDoc = doc;
			}
			if (previousDoc != null)
			{
				await processor(previousDoc, true);
			}
		}
	}
