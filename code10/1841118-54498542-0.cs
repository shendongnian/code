static void Main(string[] args)
{
	Task watchTask = WatchCollection();
	// Do other stuff here, while watching...
}
private static async Task WatchCollection()
{
	using (var cursor = collection.Watch())
	{
		await cursor.ForEachAsync(change =>
		{
			// process change event
		});
	}
}
While I was attempting to do it like this, which doesn't work:
static void Main(string[] args)
{
	using (var cursor = collection.Watch())
	{
		Task watchTask cursor.ForEachAsync(change =>
		{
			// process change event
		});
	}
	
	// Do other stuff here, while watching
}
So, the actual ForEachAsync task is awaited, while the outer Task which wraps the entire functionality is not awaited... I am either too tired or not familiar enough with Tasks to give a good explanation of why one works and the other doesn't.
