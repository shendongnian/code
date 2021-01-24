    public async Task DoTheMigration()
    {
        var users = await GetUsers();
        var tasks = users.Select
        (
            u => InsertUser(u)
        );
        await Task.WhenAll(tasks.ToArray());
    }
