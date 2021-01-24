     string RunScript(string pathToYourScript){
    RunspaceConfiguration runspaceConfiguration = RunspaceConfiguration.Create();
                //IEnumerable<PSObject> results;
                //var config = RunspaceConfiguration.Create();
    
                using (var runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration))
                {
                    runspace.Open();
                    runspace.SessionStateProxy.SetVariable("prog", this);
    
                    using (Pipeline pipeline = runspace.CreatePipeline())
                    {
                        if (!string.IsNullOrEmpty(path))
                            pipeline.Commands.AddScript(string.Format("$env:path = \"{0};\" + $env:path", pathToYourScript));
    
                        pipeline.Commands.AddScript(path);
                        pipeline.Commands.Add("Out-String");
    
                        Collection<PSObject> results = pipeline.Invoke();
                        StringBuilder stringBuilder = new StringBuilder();
                        foreach (PSObject obj in results)
                        {
                            stringBuilder.AppendLine(obj.ToString());
                            
                        }
    
                        var outDefault = new Command("out-default");
                        outDefault.MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);
                        pipeline.Commands.Add(outDefault);
    
                        return stringBuilder;
                        }
    
                    }
                }
