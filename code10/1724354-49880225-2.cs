   	public static async Task PopulateMxRecords(List<string> nsRecords)
   	{
   		var tasks = nsRecords.Select(ns => ResolveAsync(ns)).ToList();
   		
   		while (tasks.Count() > 0)
   		{
   			var task = await Task.WhenAny(tasks);
   			tasks.Remove(task);
   
   			var mxRecords = await task;
   			Console.WriteLine(mxRecords);
   		}
   	}
