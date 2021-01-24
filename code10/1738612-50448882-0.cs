    var evs = db.B_Player.Where(i => i.CurrentTeamId == teamIdEv)
                         .Select(x => new PlayerEntity // projection
                         {
                            Name = item.Name,
                            Surname = item.Surname,
                            Id = item.Id,
                            CurrentTeamId = item.CurrentTeamId
                         }).ToList();
    
    var deps= db.B_Player.Where(i => i.CurrentTeamId != teamIdEv)
                         .Select(x => new PlayerEntity // projection
                         {
                            Name = item.Name,
                            Surname = item.Surname,
                            Id = item.Id,
                            CurrentTeamId = item.CurrentTeamId
                         }).ToList();
