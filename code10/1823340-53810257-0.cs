    private Dictionary<string, Task<string>> Orgs = new Dictionary<string, Task<string>>();
    private async Task GetOrgName(Organization org)
    {	
		Task<string> nameTask;
		if (Orgs.TryGetValue(org.Id, out nameTask)
		{
			org.Name = await nameTask;
		}
		else
		{
			// Succeeding callers will not call GetOrganization any more and
			// will wait for the first one to complete.
			var tcs = new TaskCompletionSource<string>();
			Orgs[org.Id] = tcs.Task;
			
			// Consider using .ConfigureAwait(false) here...
			var result = await _directoryService.GetOrganization(org.Id);
			if (result != null)
            	org.Name = result.DisplayName;
        	else
            	org.Name = org.Id;
				
			tcs.SetResult(org.Name);
		}
    }
