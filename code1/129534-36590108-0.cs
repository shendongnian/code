    using System.Threading.Tasks;
	var task = Task.Run(() => obj.PerformInitTransaction());
	if (task.Wait(TimeSpan.FromSeconds(30)))
		return task.Result;
    else
        throw new Exception("Timed out");
