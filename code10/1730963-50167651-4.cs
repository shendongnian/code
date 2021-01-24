    using Microsoft.TeamFoundation.Core.WebApi;
    using Microsoft.VisualStudio.Services.Client;
    using Microsoft.VisualStudio.Services.Common;
    using Microsoft.VisualStudio.Services.WebApi;
    using System;
    using System.Collections.Generic;
    
    namespace GetUser
    {
        class Program
        {
            static void Main(string[] args)
            {
                            String collectionUri = "http://TFS2017:8080/tfs/defaultcollection";
            VssCredentials creds = new VssClientCredentials();
            creds.Storage = new VssClientCredentialStorage();
            VssConnection connection = new VssConnection(new Uri(collectionUri), creds);
            TeamHttpClient thc = connection.GetClient<TeamHttpClient>();
    
            List<WebApiTeam> irs = thc.GetTeamsAsync("AgileProject").Result;
    
            foreach (WebApiTeam ir in irs)
            {
                Console.WriteLine(ir.Name);
            }
    
            }
        }
    }
