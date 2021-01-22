    ProcessRoundIssueInstance.Where(i => i.GroupId != null)
        .GroupBy(i => i.GroupID)
        .Select(group => new 
                        { 
                          Key = group.Key,
                          Count = group.SingleOrDefault() == null ? 0 : 
                                  group.SingleOrDefault().Select( item => item.UserID).Distinct().Count() 
                         });
