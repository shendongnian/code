    public static void StartCommand(string cmd)
	{
		var escaped = cmd.Replace("\"", "\\\"");
		
		var process = new Process()
		{
			StartInfo = new ProcessStartInfo
			{
				FileName = "/bin/bash", // or whatever shell you use
				Arguments = $"-c \"{escaped}\"",
				UseShellExecute = false,
				CreateNoWindow = true,
			}
		};
		process.Start();
	}
