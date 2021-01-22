    using (Runspace runspace = RunspaceFactory.CreateRunspace())
    {
        runspace.Open();
        runspace.SessionStateProxy.Path.SetLocation(directory);
        using (Pipeline pipeline = runspace.CreatePipeline())
        {
            pipeline.Commands.Add(@"C:\scripts\foo.ps1");
            pipeline.Invoke();
        }
        runspace.Close();
    }
