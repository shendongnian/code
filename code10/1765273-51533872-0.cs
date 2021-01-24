    using Microsoft.TeamFoundation.SourceControl.WebApi;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services.WebApi;
    using System;
    
    namespace GetPullRequest
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                String collectionUri = "https://xxx.visualstudio.com";
                VssBasicCredential creds = new VssBasicCredential("", "6ztnrtjdd3i42juchu4xxxxxxxxxaslnseo277tgiuiq");
                VssConnection connection = new VssConnection(new Uri(collectionUri), creds);
                var git = connection.GetClient<GitHttpClient>();
                var prId = 12345;
                var pr = git.GetPullRequestByIdAsync(prId).Result;
                var RepoUrl = pr.Repository.RemoteUrl;
                var prUrl = RepoUrl + "/pullrequest/" + prId;
                Console.WriteLine(prUrl);
    
            }
        }
    }
