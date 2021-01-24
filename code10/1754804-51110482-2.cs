      using (Runspace space = RunspaceFactory.CreateRunspace())
      {
        space.Open();
        Pipeline pipeline = space.CreatePipeline();
        // Create a Command instance that runs the script and
        // attach a parameter (value) to it.
        // Note that since "test.ps1" is referenced without a path, it must
        // be located in a dir. listed in $env:PATH
        var cmd = new Command("test.ps1");
        cmd.Parameters.Add("stepx", "This is a test");
        // Add the command to the pipeline.
        pipeline.Commands.Add(cmd);
        // Note: Alternatively, you could have constructed the script-file invocation
        // as a string containing a piece of PowerShell code as follows:
        //   pipeline.Commands.AddScript("test.ps1 -stepx 'This is a test'");
        var output = pipeline.Invoke(); // output[0] == "This is a test"
      }
