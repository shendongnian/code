    DataTable tempTable = GetJobTable(jobs);
    
    using (var cmd = PrepareCommand(conn, string.Empty))
    {
    	cmd.CommandType = CommandType.StoredProcedure;
    	cmd.CommandText = "dbo.procProcessJobs";
    	SqlParameter parameter = new SqlParameter
    	{
    		ParameterName = "@Jobs",
    		SqlDbType = SqlDbType.Structured,
    		Value = tempTable
    	};
    	cmd.CommandTimeout = 12000;
    
    	cmd.Parameters.Add(parameter);
    
    	return await cmd.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
    }
    
    
    private DataTable GetJobTable(List<IJobDetail> jobs)
    {
    	DataTable results = new DataTable();
    	results.Columns.Add(ColumnSchedulerName, typeof(string));
    	results.Columns.Add(ColumnJobName, typeof(string));
    	results.Columns.Add(ColumnJobGroup, typeof(string));
    	results.Columns.Add(ColumnDescription, typeof(string));
    	results.Columns.Add(ColumnJobClass, typeof(string));
    	results.Columns.Add(ColumnIsDurable, typeof(bool));
    	results.Columns.Add(ColumnIsNonConcurrent, typeof(bool));
    	results.Columns.Add(ColumnIsUpdateData, typeof(bool));
    	results.Columns.Add(ColumnRequestsRecovery, typeof(bool));
    	results.Columns.Add(ColumnJobDataMap, typeof(byte[]));
    
    	foreach (var job in jobs)
    	{
    		byte[] baos = null;
    		if (job.JobDataMap.Count > 0)
    		{
    			baos = SerializeJobData(job.JobDataMap);
    		}
    
    		results.Rows.Add(new object[]
    		{
    			SchedulerNameLiteral,
    			job.Key.Name,
    			job.Key.Group,
    			job.Description,
    			GetStorableJobTypeName(job.JobType),
    			GetDbBooleanValue(job.Durable),
    			GetDbBooleanValue(job.ConcurrentExecutionDisallowed),
    			GetDbBooleanValue(job.PersistJobDataAfterExecution),
    			GetDbBooleanValue(job.RequestsRecovery),
    			baos
    		});
    	}
    
    	return results;
    }
