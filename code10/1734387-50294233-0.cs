    teams = connection.Team 
    .Join(connection.Player,
        t => t.ID,
        p => p.IDTeam,
        (t, p) => new { Team = t, Player = p })
    .Where(tp => tp.Player.IDTeam == tp.Team.ID
        && tp.Team.ID != team.ID
        && tp.Team.IsVisible == true
        && !tp.Team.DeleteDate.HasValue)
    .Select(tp => tp.Team)
    .ToList().GroupBy(i=>i.ID).Where(i=>i.Count()>=4);
