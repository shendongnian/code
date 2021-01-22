    var subquery =
      dc.Groups
      .OrderBy(g => g.TotalMembers)
      .Take(5);
    
    var query =
      dc.Themes
      .Join(subquery, t => t.K, g => g.ThemeK, (t, g) => new
      {
        ThemeName = t.Name, GroupName = g.Name
      }
      );
