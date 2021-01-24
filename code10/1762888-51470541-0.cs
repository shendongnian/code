    string projectFileName = Directory.GetCurrentDirectory() + "\\build\\Solution.sln";
    ProjectCollection pc = new ProjectCollection();
    Dictionary<string, string> GlobalProperty = new Dictionary<string, string>();
    GlobalProperty.Add("Configuration", "Release");
    GlobalProperty.Add("Platform", "Any CPU");
    GlobalProperty.Add("OutputPath", Directory.GetCurrentDirectory() + "\\build\\\bin\\Release");
    
    BuildParameters bp = new BuildParameters(pc);
    bp.Loggers = new[] {
      new FileLogger
      {
        Verbosity = LoggerVerbosity.Detailed,
        ShowSummary = true,
        SkipProjectStartedText = true
      }
    };
    
    BuildManager.DefaultBuildManager.BeginBuild(bp);
    
    BuildRequestData BuildRequest = new BuildRequestData(projectFileName, GlobalProperty, null, new string[] { "Build" }, null);
    
    BuildSubmission BuildSubmission = BuildManager.DefaultBuildManager.PendBuildRequest(BuildRequest);
    BuildSubmission.Execute();
    BuildManager.DefaultBuildManager.EndBuild();
    if (BuildSubmission.BuildResult.OverallResult == BuildResultCode.Failure)
      {
        throw new Exception();
      }
    }
