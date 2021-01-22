	var process = new Process
	{
		StartInfo =
		{
		FileName = "netsh.exe",
		Arguments = "wlan show interfaces",
		UseShellExecute = false,
		RedirectStandardOutput = true,
		CreateNoWindow = true
		}
	};
	process.Start();
	var output = process.StandardOutput.ReadToEnd();
	var line = output.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault(l => l.Contains("SSID") && !l.Contains("BSSID"));
	if (line == null)
	{
		return string.Empty;
	}
	var ssid = line.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries)[1].TrimStart();
	return ssid;
