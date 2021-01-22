    public static List<string> getOpenIssuesListByProject(string _projectName)
    {
        JiraSoapServiceService jiraSoapService = new JiraSoapServiceService();
        string token = jiraSoapService.login(DEFAULT_UN, DEFAULT_PW);
        string[] keys = { getProjectKey(_projectName) };
        RemoteStatus[] statuses = jiraSoapService.getStatuses(token);
        var desiredStatuses = statuses.Where(x => x.name == "Open" || x.name == "In Progress")
            .Select(x=>x.id);
        RemoteIssue[] AllIssues = jiraSoapService.getIssuesFromTextSearchWithProject(token, keys, "", 99);
        IEnumerable<RemoteIssue> openIssues = AllIssues.Where(x => desiredStatuses.Contains(x.status));
        return openIssues.Select(x => x.key).ToList();
    }
