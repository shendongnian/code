    var runspace = RunspaceFactory.CreateRunspace();
    PSSnapInException pex;
    var loadedSnapIn = Runspace.RunspaceConfiguration.AddPSSnapIn(SnapInName, out pex);
    runspace.Open();
    var pipe = runspace.CreatePipeline(commandline);
    var output = pipe.Invoke();
