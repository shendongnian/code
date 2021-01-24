            /// <summary>
            /// Gets all the completed pull requests that are created by the given identity, for the given repository
            /// </summary>
            /// <param name="gitHttpClient">GitHttpClient that is created for accessing vsts.</param>
            /// <param name="repositoryId">The unique identifier of the repository</param>
            /// <param name="identity">The vsts Identity of a user on Vsts</param>
            /// <returns></returns>
            public static List<GitPullRequest> GetAllCompletedPullRequests(
                GitHttpClient gitHttpClient, Guid repositoryId, Identity identity)
            {
                var pullRequestSearchCriteria = new GitPullRequestSearchCriteria
                {
                    Status = PullRequestStatus.Completed,
                    CreatorId = identity.Id,
                };
    
                List<GitPullRequest> allPullRequests =  gitHttpClient.GetPullRequestsAsync(
                    repositoryId,
                    pullRequestSearchCriteria,
                    skip:0, // Means skip none of the pull requests. 
                    top:1000-000-000 // you could instead use Int.MaxValue
                    ).Result;
    
                return allPullRequests;
            }
