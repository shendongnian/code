    // for VSTS    
    var connection = new VssConnection(collectionUri, credentials);
    // for TFS On-Premise
    var connection  = new TfsTeamProjectCollection(_serverUrl);
    int pullRequestId = 11;
    var client = connection.GetClient<GitHttpClient>();
    var pr = await client.GetPullRequestByIdAsync(pullRequestId);
