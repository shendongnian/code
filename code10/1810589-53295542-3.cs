    public static IEnumerable<(T Model, bool IsLast)> Map<T>(IEnumerable<T> items)
    {
        T prevModel = default(T);
        bool isFirst = true;
        foreach (var model in items)
        {
            if (!isFirst)
            {
                yield return (prevModel, false);
            }
            else
            {
                isFirst = false;
            }
            prevModel = model;
        }
        if (!isFirst)
        {
            yield return (prevModel, true);
        }
    }
	public async Task GetDocs(string id, Func<Model, bool, Task> processor)
	{
		var filter = Builders<Model>.Filter;
		var sort = Builders<Model>.Sort;
		using (var cursor = await Coll.Find(filter.Eq(f => f.id, id)).ToCursorAsync())
		{
			foreach (var docWrapper in Map(cursor.Current))
			{
			    await processor(docWrapper.Model, docWrapper.IsLast);
			}
		}
	}
