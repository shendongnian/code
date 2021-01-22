    Engine engine = new Engine();
    engine.BinPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.System)
        + @"\..\Microsoft.NET\Framework\v2.0.50727";
    FileLogger logger = new FileLogger();
    logger.Parameters = @"logfile=C:\temp\test.msbuild.log";
    engine.RegisterLogger(logger);
    string[] tasks = new string[] { "MyTask" };
    BuildPropertyGroup props = new BuildPropertyGroup();
    props.SetProperty("parm1","hello Build!");
    try
    {
      // Call task MyTask with the parm1 property set
      bool success = engine.BuildProjectFile(@"C:\temp\test.msbuild",tasks,props);
    }
    catch (Exception ex)
    {
      // your error handler
    }
    finally
    {
     engine.UnregisterAllLoggers();
     engine.UnloadAllProjects();
    }
