    var goodBots = new List<IBot>();
    var results = new IAsyncResult[Bots.Count];
    var events = new WaitHandle[Bots.Count];
    int i = 0;
    foreach (IBot bot in Bots) {
        NewGame del = bot.NewGame;
        results[i] = del.BeginInvoke(Info, null, null);
        events[i++] = r.AsyncWaitHandle;
    }
    WaitAll(events, RoundLimit);
    var goodBots = new List<IBot>();
    for( i = 0; i < events.Count; i++ ) {
        if (results[i].IsCompleted) {
            goodBots.Add(Bots[i]);
            EndInvoke(results[i]);
            results[i].Dispose();
        }
        else {
            WriteLine("bot " + i.ToString() + " eliminated by timeout.");
        }
    }
    Bots = goodBots;
