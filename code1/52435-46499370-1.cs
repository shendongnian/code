    var updateSession = new UpdateSession();
    var updateSearcher = updateSession.CreateUpdateSearcher();
    var count = updateSearcher.GetTotalHistoryCount();
    var history = updateSearcher.QueryHistory(0, count);
    for (int i = 0; i < count; ++i){
       //sets KB here!!
       string _splitstring = ExtractString(history[i].Title)
       Console.WriteLine(_splitstring);
    }
