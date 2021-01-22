    // Common code:
    var hosters = from e in context.Hosters_HostingProviderDetail
                  where e.ActiveStatusID == pendingStateId;
    // The difference between ASC and DESC:
    hosters = (sortOrder == SortOrder.ASC ? hosters.OrderBy(e => e.HostingProviderName) : hosters.OrderByDescending(e => e.HostingProviderName));
    // More common code:
    returnList = hosters.ToList<Hosters_HostingProviderDetail>();
