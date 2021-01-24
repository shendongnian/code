       using (var txscope = new TransactionScope(TransactionScopeOption.RequiresNew))
       {
                try
                {
                    using (SQLAgentJobHelper jobHelper = new SQLAgentJobHelper(ServerConnection))
                    { 
                       jobHelper.CreateJob(jobName)
                       jobHelper.AddCommandLineStep("Step 1", @"C:\Program Files\Microsoft SQL Server\130\DTS\Binn\DTEXEC.exe", C:\SSIS\CopyDataView.dtsx", Enumerable.Empty<NameValue>().ToList());
                    }
                  txscope.Complete();
                  return Ok(1);
                }
                catch (Exception ex)
                {
                    txscope.Dispose();
                    return Ok(ex.StackTrace.ToString());
                }
        }
