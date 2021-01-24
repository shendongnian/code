    public static void IncrementTodayStats(string user)
    {
        DateTime today = DateTime.Now.Date;
        var filter = Builders<UsageModel>.Filter.Eq(doc => doc.User, user);
        var update = Builders<UsageModel>.Update.
            SetOnInsert(doc => doc.History[today], 0).
            Inc(doc => doc.History[today], 1);
        var res = Collection.UpdateOne(filter, update);
    }
  
