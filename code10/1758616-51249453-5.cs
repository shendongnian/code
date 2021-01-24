	List<Task<int>> trackedTasks = new List<Task<int>>();
	var numbers = new int[]{0, 1, 2, 3, 4};
    foreach (var item in numbers)
    {
		trackedTasks.Add(new Func<Task<int>>(async () =>
        {
            var x = 0;
			(new Func<Task<int>>(async () =>{x = item; return x;}))().Wait();
			Console.WriteLine(x);
			return x;
        })());
    }
    var results = await Task.WhenAll(trackedTasks);
