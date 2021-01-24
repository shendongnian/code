    public IEnumerable<ProjectVotes> GetCountOfVotes()
    {
        using (var db = new SafetyFundDbContext(Options))
        {
            return db.Votes
                .GroupBy(vote => vote.ProjectId)
                .Select(group => new ProjectVotes
                {
                    ProjectID = group.Key,
                    Votes = group.Count()
                })
                .ToList();
       }          
    }
