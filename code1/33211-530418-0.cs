    string cmdArg = ".\script.ps1 -foo bar"            
    Collection<PSObject> psresults;
    using (Pipeline pipeline = _runspace.CreatePipeline())
                {
                    pipeline.Commands.AddScript(cmdArg);
                    pipeline.Commands[0].MergeMyResults(PipelineResultTypes.Error, PipelineResultTypes.Output);
                    psresults = pipeline.Invoke();
                }
    return psresults;
