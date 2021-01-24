    string projectName = ""; // your project
    string teamName = null; //change it for nondefault team 
    var WorkClient = Connection.GetClient<WorkHttpClient>();
    TeamContext tcx = new TeamContext(projectName, teamName);
    TeamSetting tmsettings = WorkClient.GetTeamSettingsAsync(tcx).Result; // current iteration without dates
    Console.WriteLine("Current Iteration: {0} - {1}", tmsettings.DefaultIteration.Name, tmsettings.DefaultIteration.Path);
    List<TeamSettingsIteration> iterations = WorkClient.GetTeamIterationsAsync(tcx).Result;  // full information for iterations
    foreach (TeamSettingsIteration iteration in iterations)
         Console.WriteLine("{0}: {1} : {2}-{3}", iteration.Attributes.TimeFrame, iteration.Name, iteration.Attributes.StartDate, iteration.Attributes.FinishDate);
    TeamSettingsIteration currentiteration = (WorkClient.GetTeamIterationsAsync(tcx, "Current").Result).FirstOrDefault(); // get only current
            
    if (currentiteration != null) Console.WriteLine("Current iteration - {0} : {1}-{2}", currentiteration.Name, currentiteration.Attributes.StartDate, currentiteration.Attributes.FinishDate);
