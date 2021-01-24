    ProjectRollup projectRollup = new ProjectRollup()
    {
    	Jobs = new List<JobForRollup>()
    	{
    		new JobForRollup()
    		{
    			JobID = Guid.NewGuid(),
    			JobName = "job1",
    			Price = 434,
    			ScheduledStart = DateTime.Now,
    			WorkItems = new List<WorkItemForRollup>()
    			{
    				new WorkItemForRollup()
    				{
    					Description="item1",
    					Price = 34,
    					ScheduledDate = DateTime.Now
    				}
    			}
    		}
    	}
    };
