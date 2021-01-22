    using (Runspace runspace = RunspaceFactory.CreateRunspace())
    {
        System.Environment.CurrentDirectory = "C:\\scripts";
        runspace.Open();
        using (Pipeline pipeline = runspace.CreatePipeline())
        {
            pipeline.Commands.Add(@".\foo.ps1");
            pipeline.Invoke();
        }
        runspace.Close();
    }
