    private class SponsorLevelGroup : ISponsorLevelGroup
    {
       public string Level { get; set; }
       public IList<Sponsor> Sponsors { get; set; }
    }
    
    var result = ( from s in db.Sponsors
                   join sl in sb.SponsorLevels on s.SponsorLevelId equals sl.SponsorLevelId
                   select new Sponsor 
                   {
                     Name = s.Name,
                     Level = sl.LevelName
                   }
                 ).GroupBy(s => s.LevelName)
                  .Select(g => new SponsorLevelGroup
                                   {
                                       Level = g.Key,
                                       Sponsors = g.ToList()
                                    }) ;
