    public void Refresh(object sender = null, EventArgs e = null)
    {
        Leagues = _Locator.Statistix.Leagues.Select(x => new League
            {
                 Id = x.Id,
                 Name = x.Name,
                 Initials = x.Initials,
                 LahmanId = x.LahmanId,
                 Teams = x.Teams.Where(x => x.Year == SelectedYear).ToList()
            }).Where(x=> x.Teams.Count > 0).ToList();
    }
