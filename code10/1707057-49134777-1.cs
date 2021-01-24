    public async Task<IActionResult> TheAction(string id)
    {
        Team team = await _context.Teams.SingleOrDefaultAsync(x => x.TeamID == id).Include(t => t.Tournaments);
        //You should be able to eager load the teams at this point since you don't use virtual, put a break point to check. If not, you can load them using .ThenInclude()
    
        TeamVM model = new TeamVM
        {
            ID = team.TeamID,
            Name = team.TeamName,
            Captain = team.Captain,
            Tournaments = team.Tournaments.Select(tournament => new TournamentVM() 
            {
                ID = tournament.TournamentID,
                Date = tournament.TournamentDate,
                Place = tournament.Place,
                Competitor = (tournament.TeamA == team) ? tournament.TeamB.Name : tournament.TeamA.TeamName
                //pick the other team as competitor
            }).OrderBy(x => x.Date)
        };
        return View(model);
    }
