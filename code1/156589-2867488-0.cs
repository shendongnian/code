    IEnumerable<RemoteIssue> openIssues = AllIssues.Where(x=>
    {
        foreach (var v in desiredStatuses)
        {
            if (x.status == v)
                return true;
            else
                return false;
        }
        return false;
    });
