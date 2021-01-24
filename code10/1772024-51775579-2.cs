    static async Task<string> mytest()
    {
        var auth = new MvcAuthorizer
        {
            CredentialStore = new SessionStateCredentialStore()
        };
        var twitterCtx = new TwitterContext(auth);
        List<DMEvent> AllDmEvents = new List<DMEvent>();
        string Cursor;
        DirectMessageEvents dmResponse =
            await
                (from dm in twitterCtx.DirectMessageEvents
                 where dm.Type == DirectMessageEventsType.List &&
                 dm.Count == 10
                 select dm)
                .SingleOrDefaultAsync(); //In debugging mode, after this line is executed, it will go away and keep loading forever and never come back
        AllDmEvents.AddRange(dmResponse.Value.DMEvents);
        Cursor = dmResponse.Value.NextCursor;
        string xxx = (JsonConvert.SerializeObject(AllDmEvents, Formatting.None));
        return xxx;
