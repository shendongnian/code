    [HttpPost]
    public async Task<IActionResult> PostCall()
    {
        var tasks = Enumerable
            .Range(0, 10)
            .Select(Manager.SomeMethodAsync)
            .ToList();
        foreach (var task in tasks)
            HostingEnvironment.QueueBackgroundWorkItem(_ => task);
        while (tasks.Any())
        {
            var readyTask = await Task.WhenAny(tasks);
            tasks.Remove(readyTask);
            if (await readyTask)
                return new ObjectResult("At least one task returned true");
        }
        return new ObjectResult("No tasks returned true");
    }
