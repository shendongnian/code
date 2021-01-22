    List<string> targets = new List<string>() {"Johan", "Ekberg"};
    int targetCount = targets.Count;
    //
    List<Users> result = 
      dc.Names
        .Where(n => targets.Contains(n.Name))
        .SelectMany(n =>
          dc.ConnectNames.Where(cn => cn.NameId == n.NameId)
        )
        .GroupBy(cn => cn.UserId)
        .Where(g => g.Count() == targetCount)
        .SelectMany(g =>
          dc.Users.Where(u => u.UserId == g.Key)
        )
        .ToList();
