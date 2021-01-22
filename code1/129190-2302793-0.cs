	public void run(string script)
	{
		IEnumerable<PSObject> results;
		var config = RunspaceConfiguration.Create();
		var host = new ScriptHost();
		using (var runspace = RunspaceFactory.CreateRunspace(host, config))
		{
			runspace.Open();
			runspace.SessionStateProxy.SetVariable("prog", this);
			using (var pipeline = runspace.CreatePipeline())
			{
				if (!string.IsNullOrEmpty(scriptPath))
					pipeline.Commands.AddScript(string.Format("$env:path = \"{0};\" + $env:path", scriptPath));
				pipeline.Commands.AddScript(script);
				var outDefault = new Command("out-default");
				outDefault.MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);
				pipeline.Commands.Add(outDefault);
				results = pipeline.Invoke();
			}
		}
	}
