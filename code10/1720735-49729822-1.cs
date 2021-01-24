    public int GetCountOfVotes(int projectId)
    {
        using (var db = new SafetyFundDbContext(Options))
        {
            return db.Votes
                .Where(vote => vote.ProjectId == projectId)
                .Count();    
       }          
    }
