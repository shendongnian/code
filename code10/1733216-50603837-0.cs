	const string cSplitString = "target=";
	var targets = new List<string>();
	var proc = new Process
	{
		StartInfo = new ProcessStartInfo
		{
			FileName = "cmdkey.exe",
			Arguments = "/list",
			UseShellExecute = false,
			RedirectStandardOutput = true,
			CreateNoWindow = true
		}
	};
	proc.Start();
	while (!proc.StandardOutput.EndOfStream) {
		string line = proc.StandardOutput.ReadLine();
		if (line.Contains(cSplitString))
			targets.Add(line.Substring(line.IndexOf(cSplitString)+cSplitString.Length));
	}
