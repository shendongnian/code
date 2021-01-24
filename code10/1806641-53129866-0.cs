    using (var webClient = new WebClient())
    {
        webClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
        webClient.Headers.Add(HttpRequestHeader.AcceptEncoding, ": gzip, deflate, br");
        var json = webClient.DownloadString("https://stats.nba.com/stats/teamyearbyyearstats?TeamID=1610612746&LeagueID=00&PerMode=Totals&SeasonType=Regular%20Season");
        Console.WriteLine(json);
    }
