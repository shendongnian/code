    var tasks = new[] { 1, 2, 3, 4, 5 }
        .Select
        (
            x => new Task( () => Console.WriteLine(x) )
        );
    var superTask =
        tasks.Aggregate
        (
            Task.CompletedTask,
            async (task1, task2) =>
            {
                await task1;
                await Task.Delay(1000);
                task2.Start();
            }
        );
    await superTask;
