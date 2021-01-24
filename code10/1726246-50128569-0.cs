                String collectionUri = "http://collectionurl/";
                VssCredentials creds = new VssClientCredentials();
                creds.Storage = new VssClientCredentialStorage();
                VssConnection connection = new VssConnection(new Uri(collectionUri), creds);
                TeamHttpClient thc = connection.GetClient<TeamHttpClient>();
                List<IdentityRef> irs = thc.GetTeamMembersAsync("ProjectName","TeamName").Result;
                foreach (IdentityRef ir in irs)
                {
                    Console.WriteLine(ir.UniqueName);
                    Console.WriteLine(ir.DisplayName);
                }
