                String collectionUri = "http://TFS2017:8080/tfs/defaultcollection";
                VssCredentials creds = new VssClientCredentials();
                creds.Storage = new VssClientCredentialStorage();
                VssConnection connection = new VssConnection(new Uri(collectionUri), creds);
                var whc = connection.GetClient<WorkHttpClient>();
                var capacity = whc.GetCapacitiesAsync(new Microsoft.TeamFoundation.Core.WebApi.Types.TeamContext("Teamproject"), new Guid("Iterationid")).Result;
                var daysoff = whc.GetTeamDaysOffAsync(new Microsoft.TeamFoundation.Core.WebApi.Types.TeamContext("Teamproject"), new Guid("Iterationid")).Result;
