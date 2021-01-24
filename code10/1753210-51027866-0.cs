    var tfs = new TfsTeamProjectCollection(uri, tfsCredential);
    var service = tfs.GetService<ICommonStructureService>();
    // TODO var iteration = GetIteration();    
    var projectInfo = service.GetProjectFromName(projectName)
    var nodes = service.ListStructures(projectInfo.Uri);
    service.DeleteBranches(iteration.Id, nodes[0].Uri);
