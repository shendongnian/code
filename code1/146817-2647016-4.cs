    public static List<Issue> FindOpenIssues(this IList<Issue> issues) {
        return issues
                  .Where(i => i.issueStatus.Any(stat => stat.Status == "Open")
                  .ToList();
    }
