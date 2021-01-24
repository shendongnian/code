    public async Task<IActionResult> TheAction(string id){
    Team team = await _context.Teams.Where(x => x.TeamID == id).Include(x => x.TeamA).Include(x => x.TeamB).SingleOrDefaultAsync();
    var gamesList = (from x in _context.Tournaments
                        .Where(x => x.TeamAID == id || x.TeamBID == id)
                        select new TournamentVM
                        {
                            ID = x.TournamentID,
                            Date = x.TournamentDate,
                            Place = x.Place,
                            Competitor = x.TeamAID == id ? x.TeamB.TeamName : x.TeamA.TeamName
                        });
    TeamVM model = new TeamVM
    {
        ID = team.TeamID,
        Name = team.TeamName,
        Captain = team.Captain,
        Tournaments = from x in gamesList
            .Select(x => new TournamentVM
            {
                ID = x.ID,
                Date = x.Date,
                Place = x.Place,
                Competitor = x.Competitor
            }).OrderBy(x => x.Date) select x
    };
    return View("TheAxion", model);}
:-)
