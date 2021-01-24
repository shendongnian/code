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
         List<GitPullRequest> allPullRequests = new List<GitPullRequest>();
         int skip = 0;
         int threshold = 1000;
         while(true){
             List<GitPullRequest> partialPullRequests =  gitHttpClient.GetPullRequestsAsync(
                 repositoryId,
                 pullRequestSearchCriteria,
                 skip:skip, 
                 top:threshold 
                 ).Result;
             allPullRequests.AddRange(partialPullRequests);
             if(partialPullRequests.Length < threshold){break;}
             skip += threshold
        }
         return allPullRequests;
     }
             
          
