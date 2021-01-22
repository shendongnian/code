    var anonymous = GetAnonymousCollection();
    IEnumerable<Agency> = anonymous
        .GroupBy(a => a.AgencyID)
        .Select(ag => new Agency()
        {
            AgencyID = ag.Key,
            AgencyName = ag.First().AgencyName,
            Rules = ag
                .GroupBy(agr => agr.AudiRuleID)
                .Select(agrg => new AuditRule()
                {
                    AuditRuleID = agrg.Key,
                    AuditRuleName = agrg.First().Name,
                    AvgDaysWorked = agrg.Avg(agrgr => agrgr.DaysWorked)
                }
          }
