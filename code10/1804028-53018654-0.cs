    string tsScript = $"mstsc /v:{machinename}";
    string cmdKey = $"cmdkey /generic:{machinename} /user:{username} /pass:{password}";
    
    using (Runspace rs = RunspaceFactory.CreateRunspace())
    {
    	rs.Open();
    
    	using (Pipeline pl = rs.CreatePipeline())
    	{
    		pl.Commands.AddScript(cmdKey);
    		pl.Commands.AddScript(tsScript);
    		pl.Invoke();
    	}
    }
