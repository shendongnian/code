    public async Task<List<Status>> GetTweetByKey(string[] keys, StatusType statusType)
    {
        try
        {
            return await (
            from tweet in _twitterContext.Status
            join key in keys on tweet.ID equals Convert.ToUInt64(key)
            where tweet.Type == statusType &&
                  tweet.TweetMode == TweetMode.Extended &&
                  tweet.IncludeEntities == true
            select tweet).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }
