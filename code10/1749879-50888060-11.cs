	public async Task<IEnumerable<Task<User>>> GetUserTasksAsync(int groupId)
	{
		var group = await GetGroupAsync(groupId);
		return group.UserIds.Select(GetUserAsync);
	}
    foreach (var task in await GetUserTasksAsync(1))
    {
        var user = await task;
        ...
    }
