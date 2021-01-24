            DateTime today = DateTime.Now;
            DateTime lastWeek = DateTime.Now.AddDays(-7);
            PipelineRunFilterParameters prfp = new PipelineRunFilterParameters(lastWeek, today);
            var x = client.PipelineRuns.QueryByFactory("yourResourceGroupName", "DatafactoryInstanceName", prfp);
            var enumerator = x.Value.GetEnumerator();
            PipelineRun pipeRun;
            string runId;
            string pipeName = "theNameOfYourPipeline";
            while (enumerator.MoveNext())
            {
                pipeRun = enumerator.Current;
                if(pipeRun.PipelineName == pipeName)
                {
                    runId = pipeRun.RunId;
                    break;
                }
            }
