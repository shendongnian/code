        Task<string> nameTask;
        if (!Orgs.TryGetValue(org.Id, out nameTask)
        {
            nameTask = GetOrganization(.org);
            Orgs.Add(org.Id, nameTask);
        }
    
        await nameTask;
    }
    private async Task GetOrganization(Organization org)
    {
        // Consider using .ConfigureAwait(false) here...
        var result = await _directoryService.GetOrganization(org.Id);
        if (result != null)
            org.Name = result.DisplayName;
        else
            org.Name = org.Id;
    }
