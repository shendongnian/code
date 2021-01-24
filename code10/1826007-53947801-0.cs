                var url = new Uri("http://tfsServer:8080/tfs/MyCollection/");
                var connection = new VssConnection(url, new VssCredentials());
                var buildServer = connection.GetClient<BuildHttpClient>();           
                // Get the list of build definitions.
                var  definition = buildServer.GetDefinitionAsync("teamprojectname", 33).Result;
                
                //It requires project's GUID, so we're compelled to get GUID by API.
                var res = buildServer.QueueBuildAsync(new Build
                {
                    Definition = new DefinitionReference
                    {
                        Id = definition.Id
                    },
                    Project = definition.Project
                });
                Console.WriteLine($"Queued build with id: {res.Id}");
