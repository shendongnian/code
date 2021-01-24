            /// <summary>
            /// Creates a pull request, and then adds a reviewer to it.
            /// </summary>
            /// <param name="gitHttpClient"> GitHttpClient that is created for accessing vsts</param>
            /// <param name="gitPullRequest"> the pull request to be created</param>
            /// <param name="repositoryId"> the unique identifier of the repository</param>
            /// <param name="reviewerAlias"> reviewer's alias in vsts</param>
            /// <param name="vstsAccountUrl">vsts account's url</param>
            /// <param name="personalToken"> personal access token to access the vsts account. </param>
            public static async void CreatePullRequestAndAddReviewer(
                GitHttpClient gitHttpClient,
                GitPullRequest gitPullRequest,
                string repositoryId,
                string reviewerAlias,
                Uri vstsAccountUrl,
                string personalToken)
            {
                // 1- Create the pull request.
                GitPullRequest pullRequest = gitHttpClient.CreatePullRequestAsync(gitPullRequest, repositoryId, cancellationToken: CancellationToken.None).Result;
    
                // 2- Create an Identity Client to get the reviewer's vsts id
                IdentityHttpClient identityHttpClient = CreateIdentityClient(vstsAccountUrl, personalToken);
    
                // 3- Find the reviewer's vsts identity.
                Identity identity = SearchForReviewerVstsIdentity(identityHttpClient, reviewerAlias).Result;
    
                // 4- Create a IdentityRefWithVote for the reviewer
                IdentityRefWithVote identityRefWithVote = new IdentityRefWithVote
                {
                    Id = identity.Id.ToString(),
                    IsRequired = true // false otherwise.
                };
    
                // 5- Finally add the reviewer to the pull request.
                await AddReviewerToPullRequest(gitHttpClient, pullRequest, identityRefWithVote);
            }
    
            /// <summary>
            /// Creates an identity client. This is needed for fetching a reviewer's vsts identity. 
            /// </summary>
            /// <param name="vstsAccountUrl">vsts account's url</param>
            /// <param name="personalToken"> personal access token to access the vsts account. </param>
            /// <returns>an IdentityHttpClient to use for retrieving identities from vsts. </returns>
            public static IdentityHttpClient CreateIdentityClient(Uri vstsAccountUrl, string personalToken)
            {
                var vstsCredential = new VssBasicCredential(string.Empty, personalToken);
                IdentityHttpClient identityHttpClient = new IdentityHttpClient(vstsAccountUrl, vstsCredential);
                return identityHttpClient;
            }
    
            /// <summary>
            /// Given an alias on vsts, searches for its vsts identity.
            /// </summary>
            /// <param name="identityHttpClient"> is the vsts identity client.</param>
            /// <param name="alias">is the alias for which the identity is being searched for.</param>
            public static async Task<Identity> SearchForReviewerVstsIdentity(IdentityHttpClient identityHttpClient, string alias)
            {
                try
                {
                    // Notice : you can also search based on factors other than alias. 
                    IdentitiesCollection identitiesPerAlias = await identityHttpClient
                        .ReadIdentitiesAsync(IdentitySearchFilter.Alias, alias).ConfigureAwait(false);
                    if (identitiesPerAlias.Count == 1) // Found one identity-- the ideal case
                    {
                        return identitiesPerAlias[0];
                    }
    
                    Console.WriteLine($"Encountered a problem finding vsts identity foralias {alias}.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception when looking for vsts identity for alias {alias}. {ex}");
                }
    
                // Notice : watch out for null case... 
                return null;
            }
    
            /// <summary>
            /// Adds a reviewer to a an already created pull request.
            /// </summary>
            /// <param name="gitHttpClient">GitHttpClient that is created for accessing vsts</param>
            /// <param name="pullRequest"> pull request that is already created.</param>
            /// <param name="identity">identity of the reviewer that we want to add to the pull request.</param>
            public static async Task AddReviewerToPullRequest(GitHttpClient gitHttpClient, GitPullRequest pullRequest, IdentityRefWithVote identity)
            {
                identity = await gitHttpClient.CreatePullRequestReviewerAsync(
                    identity,
                    pullRequest.Repository.Id,
                    pullRequest.PullRequestId,
                    identity.Id).ConfigureAwait(false);
            }
        
