Partitioner.Create(0, 500000, 10000).AsParallel().Select(async range =>
{
    for (var i = range.Item1; i < range.Item2; i++)
    {
        var keys = await _database.ExecuteAsync("SCAN", "0", "MATCH", pattern).ContinueWith(x =>
            {
                return Task.FromResult(((RedisResult[]) ((RedisResult[]) x.Result)[1]).Select(y => (string) y));
            }).Unwrap();
        await Task.WhenAll(keys.Select(key => _database.StringGetAsync(key)));
    }
})).Wait();
And of course, it is not that clean. Unless anyone else has a better solution this is what I am going with.
