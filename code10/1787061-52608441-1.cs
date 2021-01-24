    public async Task<List<Status>> GetTweetByKeys(string[] keys, StatusType statusType)
    {
        var tasks = keys.Select(key => GetTweetByKey(key, statusType)).ToArray();
        var results = await Task.WhenAll(tasks);
        return results.ToList();
    }
    public async Task<Status> GetTweetByKey(string key, StatusType statusType)
    {
        try
        {
            return await (
            from tweet in _twitterContext.Status
            where tweet.Type == statusType &&
                  tweet.ID == Convert.ToUInt64(key) &&
                  tweet.TweetMode == TweetMode.Extended &&
                  tweet.IncludeEntities == true
            select tweet).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
