	var subscription = Events
		.Where(x => x.Action == Action.JobComplete)
		.Subscribe(x => 
		{
			if(x.Success)
			{
				//...
			}
			else
			{
				//...
			}
		});
