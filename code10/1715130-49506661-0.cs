    public class Orchestrator()
	{
		public Task ExecuteAsync()
		{
			// Create the Batch pool, which contains the compute nodes 
            // that execute the tasks.
			var pool = await _batchManager.CreatePoolIfNotExistsAsync();
			// Create the job that runs the tasks.
			var job = await _batchManager.CreateJobIfNotExistsAsync(_domain, pool.Id);
			// Obtain the bound job from the Batch service
			await job.RefreshAsync();
			// Create a collection of tasks and add them to the Batch job. 
			var tasks = await _fileProcessingTasksFactory.CreateAsync(job.Id);
			// Add the tasks to the job; the tasks are automatically scheduled
            // for execution on the nodes by the Batch service.
			await job.AddTaskAsync(tasks);
			job.OnAllTasksComplete = OnAllTasksComplete.TerminateJob;
			await job.CommitAsync();
		}
	}
	
	public class BatchManager()
	
		public async Task<CloudPool> CreatePoolIfNotExistsAsync()
        {
			// Code to create and return a pool.
		}
		public async Task<CloudJob> CreateJobIfNotExistsAsync(string domain, string poolId)
		{
			// Job id cannot contain : so replace them.
			var jobId = $"{domain}-{DateTime.UtcNow:s}".Replace(":", "-");
			var job = _parameters.BatchClient.JobOperations.CreateJob();
			job.Id = jobId;
			job.PoolInformation = new PoolInformation { PoolId = poolId };
			
			await job.CommitAsync();
			return job;
		}
	}
