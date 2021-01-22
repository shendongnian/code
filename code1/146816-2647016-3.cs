    public static List<Issue> FindOpenIssues(this IList<Issue> issues) {
        return issues
                .Where(i => i.issueStatus
                                 .OrderBy(stat => stat.CreatedOn)
                                 .First()
                                 .Status == "Open"
                      )
                .ToList();
    }
