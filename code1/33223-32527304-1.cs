    /// <summary>
    /// Runs a PowerShell script taking it's path and parameters.
    /// </summary>
    /// <param name="scriptFullPath">The full file path for the .ps1 file.</param>
    /// <param name="parameters">The parameters for the script, can be null.</param>
    /// <returns>The output from the PowerShell execution.</returns>
    public static ICollection<PSObject> RunScript(string scriptFullPath, ICollection<CommandParameter> parameters = null)
    {
    	var runspace = RunspaceFactory.CreateRunspace();
    	runspace.Open();
    	var pipeline = runspace.CreatePipeline();
    	var cmd = new Command(scriptFullPath);
    	if (parameters != null)
    	{
    		foreach (var p in parameters)
    		{
    			cmd.Parameters.Add(p);
    		}
    	}
    	pipeline.Commands.Add(cmd);
    	var results = pipeline.Invoke();
    	pipeline.Dispose();
    	runspace.Dispose();
    	return results;
    }
