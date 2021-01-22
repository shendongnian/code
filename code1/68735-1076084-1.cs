    // GetAnonymousCollection() is hard to define... ;)
    var anonymous = GetAnonymousCollection();
    IEnumerable<Agency> result = anonymous
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
                    AuditRuleName = agrg.First().AuditRuleName,
                    AvgDaysWorked = (Int32)agrg.Average(agrgr => agrgr.DaysWorked)
                })
          });
