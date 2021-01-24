      public void GetAllPullRequestsForCommit(Guid repoId, string commitId)
        {
            var query = new GitPullRequestQuery();
            var input = new GitPullRequestQueryInput() { Type = GitPullRequestQueryType.Commit, Items = new List<string>() { commitId } };
        
            query.QueryInputs = new List<GitPullRequestQueryInput>() { input };
            var response = _gitClient.GetPullRequestQueryAsync(query, repoId).Result;
        
            var samplePullRequest =  response.Results.SelectMany(x => x.Values).First().First().PullRequestId;
        }
