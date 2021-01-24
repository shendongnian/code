	async Task Main()
	{
		var reporter = new ConsoleProgress();
		var result = await WeatherWaxProgressWrapper(() => GetAsync("foo"), reporter);
		
		Console.WriteLine(result);
	}
	
	
	public async Task<int> GetAsync(string uri)
	{
		await Task.Delay(TimeSpan.FromSeconds(10));
		return 1;
	}
	
	public async Task<T> WeatherWaxProgressWrapper<T>(Func<Task<T>> method, System.IProgress<string> progress)
	{
		var task = method();
		while(!task.IsCompleted && !task.IsCanceled && !task.IsFaulted)
		{
			await Task.WhenAny(task, Task.Delay(1000));
			progress.Report("I ain't dead");
		}
		return await task;
	}
	
	public class ConsoleProgress : System.IProgress<string>
	{
		public void Report(string value)
		{
			Console.WriteLine(value);
		}
	}
