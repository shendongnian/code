    public List<IGrouping<DateTime, Game>> getGamesList(int leagueID)
    {
        var sortedGameList =
            from g in Games
            group g by g.Date;
    
        return sortedGameList.ToList();
    }
