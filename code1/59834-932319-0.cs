    Dictionary<TournamentTeam, double> wins = new Dictionary<TournamentTeam, double>();
    Dictionary<TournamentTeam, double> score = new Dictionary<TournamentTeam, double>();
    Dictionary<TournamentTeam, int> ranks = new Dictionary<TournamentTeam, int>();
    
    int r = 1;
    
    ranks = (
        from name 
        in wins.Keys 
        orderby wins[name] descending, scores[name] descending
        select new { Name = name, Rank = r++ })
        .ToDictionary(item => item.Name, item => item.Rank);
