    internal List<Draft> DraftOrder
    {
     get
     {
        List<Draft> _draftorder = new List<Draft>();
        List<DraftPick> teamPicks = new List<DraftPick>();
        foreach (Team t in teams.OrderBy(t => t.winpct))
        {
            teamPicks.AddRange(t.DraftPicks.Where(s => s.season == season));
        }
        int i = 1;
        foreach (DraftPick d in teamPicks)
        {
            _draftorder.Add(new Draft
            {
                team = teams.Find(t => t.teamid == d.currentTeamId).TeamName,
                round = d.round,
                pick = i++
            });
             if(i==6) //ADD CODE
                i=1;
        }
        return _draftorder;
     }
    }
