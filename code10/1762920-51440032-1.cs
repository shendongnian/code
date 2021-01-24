    var serverUrl = new Uri("https://account.visualstudio.com");
    var credentials = new VssBasicCredential("", PAT);
    var teamProjectName = "[replace with team project name]";
    
    using (var connection = new VssConnection(serverUrl, credentials))
    using (var rmClient = connection.GetClient<ReleaseHttpClient2>())
    using (var buildClient = connection.GetClient<BuildHttpClient>())
    {
        // Get the first build definition
        var releaseDefinition = rmClient.GetReleaseDefinitionsAsync(teamProjectName, null, ReleaseDefinitionExpands.Artifacts).Result[0];
        var primaryArtifact = releaseDefinition.Artifacts.Where(a => a.IsPrimary).SingleOrDefault();
        var projectName = primaryArtifact.DefinitionReference["project"].Id;
        var buildDefinitionId = Convert.ToInt32(primaryArtifact.DefinitionReference["definition"].Id);
    
        // Get the latest successful build from the project and build definition id
        var lastBuild = buildClient.GetBuildsAsync(projectName, new[] { buildDefinitionId }, statusFilter: BuildStatus.Completed).Result
                                    .OrderByDescending(b => b.Id)
                                    .FirstOrDefault();
    
        // Create the draft release, and associate it to the latest corresponding build
        var metadata = new ReleaseStartMetadata
        {
            DefinitionId = releaseDefinition.Id,
            IsDraft = true,
            Description = "Draft",
            Artifacts = new[]
            {
                new ArtifactMetadata
                {
                    Alias = primaryArtifact.Alias,
                    InstanceReference = new BuildVersion
                    {
                        Id = lastBuild.Id.ToString(),
                        Name = lastBuild.BuildNumber
                    }
                }
            }
        };
        var release = rmClient.CreateReleaseAsync(metadata, teamProjectName).Result;
    
        // Update the draft release variable
        release.Variables["Variable-A"].Value = "Test A";
        release.Variables["Variable-B"].Value = "Test B";
        release.Environments[0].Variables["Var-Env-A"].Value = "Test C";
        release = rmClient.UpdateReleaseAsync(release, teamProjectName, release.Id).Result;
    
        // Activate the release
        var updateMetadata = new ReleaseUpdateMetadata { Status = ReleaseStatus.Active, Comment = "Yeah baby, yeah" };
        release = rmClient.UpdateReleaseResourceAsync(updateMetadata, teamProjectName, release.Id).Result;
    
        // Trigger the deployment on a specific environment
        release.Environments[0].Status = EnvironmentStatus.InProgress;
        release = rmClient.UpdateReleaseAsync(release, teamProjectName, release.Id).Result;
