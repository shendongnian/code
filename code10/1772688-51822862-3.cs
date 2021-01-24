	[WebMethod]
	public static object GetGraphData()
	{
		Random random = new Random();
		List<Dictionary<string, object>> processes = new List<Dictionary<string, object>>();
		List<string> labels = new List<string>();
		List<string> yKeys = new List<string>();
		bool labelsDone = false;
		int nbLines = random.Next(2, 5);
		int nbProcesses = random.Next(2, 5);
		for (int i = 0; i < nbLines; i++)
		{
			Dictionary<string, object> processLine = new Dictionary<string, object>();
			string time = DateTime.Now.AddMinutes(i).ToString();
			processLine.Add("datetime", time);
			for (int j = 0; j < nbProcesses; j++)
			{
				processLine.Add($"processName{j + 1}", random.Next(100));
				if (!labelsDone)
				{
					labels.Add($"Process Name{j + 1}");
					yKeys.Add($"processName{j + 1}");
				}
			}
			labelsDone = true;
			processes.Add(processLine);
		}
		return new
		{
			labels = labels,
			ykeys = yKeys,
			processes = processes
		};
	}
