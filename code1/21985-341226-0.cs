    List<string> targets = new List<string>() {"Johan", "Ekberg"};
    int targetCount = targets.Count;
    //
    List<Users> result = 
      dc.ConnectNames
        .Where(cn => targets.Contains(
          dc.Names
            .Where(n => cn.NameId = n.NameId)
            .Select(n => n.Name)
            .First()
        )
        .GroupBy(cn => cn.UserId)
        .Where(g => g.Count() == targetCount)
        .Select(g => dc.Users.Where(u => u.UserId == g.Key) )
        .ToList();
