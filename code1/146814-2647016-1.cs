    public static List<Issue> FindOpenIssues(this IList<Issue> issues) {
        return issues
                  .Where(i => i.issueStatus.Min(stat => stat.CreatedOn).Status == "Open")
                  .ToList();
    }
