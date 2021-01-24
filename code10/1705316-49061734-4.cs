    Team team = db.Teams.Where(x => x.TeamID == teamId).FirstOrDefault();
    if (team == null) { ... }; // error
    TeamVM model = new TeamVM
    {
        ID = team.TeamID,
        Name = team.TeamName,
        Captain = team.Captain,
        // join the collections into a new collection of TournamentVM
        Tournaments = team.TeamA.Where(x => x.TeamAID == team.TeamID).Select(x => new TournamentVM
        {
            ID = x.TournamentID,
            Date = x.TournamentDate,
            Place = x.Place,
            Competitor = x.TeamB.TeamName
        }).Concat(team.TeamB.Where(x => x.TeamBID == team.TeamID).Select(x => new TournamentVM
        {
            ID = x.TournamentID,
            Date = x.TournamentDate,
            Place = x.Place,
            Competitor = x.TeamA.TeamName
        })).OrderBy(x => x.Date)
    };
    return View(model);
