	const string cSplitString = "target="; // word "target" might differ in other languages
	var targets = new List<string>();
	var proc = new Process // We need separate process to get the output
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
    // reading output from the process
	while (!proc.StandardOutput.EndOfStream) {
		string line = proc.StandardOutput.ReadLine();
		if (line.Contains(cSplitString))
			targets.Add(line.Substring(line.IndexOf(cSplitString)+cSplitString.Length));
	}
