    public static List<Issue> FindOpenIssues(this IList<Issue> issues) {
        return issues
                .Where(i => i.issueStatus
                                 // This potentially should be (I left your original logic, though):
                                 // .OrderByDescending(stat => stat.CreatedOn)
                                 .OrderBy(stat => stat.CreatedOn)
                                 .First()
                                 .Status == "Open"
                      )
                .ToList();
    }
