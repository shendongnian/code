    using System.Threading;
    using Microsoft.TeamFoundation.SourceControl.WebApi;
    using Microsoft.VisualStudio.Services.WebApi;
    
    namespace CreateVstsPullRequestAndSetAutoComplete
    {
        public class PullRequestAutoCompleter
        {
            /// <summary>
            /// Creates a pull request, and then sets it to auto complete. 
            /// </summary>
            /// <param name="gitHttpClient">GitHttpClient that is created for accessing vsts repo, and codebase.</param>
            /// <param name="repositoryId">The unique identifier of the repository</param>
            /// <param name="pullRequest">The pull request to be created, and then set autocomplete.</param>
            /// <param name="mergeCommitMessage">Provides text to post, when the pull request is completed and merged.</param>
            public static GitPullRequest CreatePullRequestAndSetAutoComplete(GitHttpClient gitHttpClient, string repositoryId, GitPullRequest pullRequest, string mergeCommitMessage)
            {
                // 1- Create the pull request.
                pullRequest = gitHttpClient.CreatePullRequestAsync(
                    pullRequest, 
                    repositoryId, 
                    cancellationToken: CancellationToken.None).Result;
    
                //2- Set autocomplete.
                pullRequest = EnableAutoCompleteOnAnExistingPullRequest(gitHttpClient, pullRequest, mergeCommitMessage);
    
                return pullRequest;
            }
    
            /// <summary>
            /// Sets an existing (meaning created earlier) pullrequest to complete automatically, 
            /// once all of its completion conditions are resolved.
            /// (i.e., a(many) reviewer(s) has(have) approved the pull request, the author has resolved all the commits, and etc)
            /// </summary>
            /// <param name="gitHttpClient">GitHttpClient that is created for accessing vsts repo, and codebase.</param>
            /// <param name="pullRequest">Is an existing pull request, meaning it was created before.</param>
            /// <param name="mergeCommitMessage">Provides text to post, when the pull request is completed and merged.</param>
            /// <returns>An updated pull request, where the update is maninly about setting the autocomplete on it. </returns>
            public static GitPullRequest EnableAutoCompleteOnAnExistingPullRequest(GitHttpClient gitHttpClient, GitPullRequest pullRequest, string mergeCommitMessage)
            {
                var pullRequestWithAutoCompleteEnabled = new GitPullRequest
                {
                    AutoCompleteSetBy = new IdentityRef { Id = pullRequest.CreatedBy.Id },
                    CompletionOptions = new GitPullRequestCompletionOptions
                    {
                        SquashMerge = true,
                        DeleteSourceBranch = true, // false if prefered otherwise
                        MergeCommitMessage = mergeCommitMessage
                    }
                };
    
                GitPullRequest updatedPullrequest = gitHttpClient.UpdatePullRequestAsync(
                    pullRequestWithAutoCompleteEnabled, 
                    pullRequest.Repository.Id, 
                    pullRequest.PullRequestId).Result;
    
                return updatedPullrequest;
            }
        }
    }
