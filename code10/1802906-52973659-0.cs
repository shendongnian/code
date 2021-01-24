    public async Task<string> YourMethod()
    {
        var ad = await jira.Issues.GetIssuesFromJqlAsync("PROJECT = MyProject AND ISSUETYPE = DEFECT");
        return ad.ToString();
    }
