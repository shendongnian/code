    public static double GetAudioDuration(string soxPath, string audioPath)
    {
    	double duration = 0;
    	var startInfo = new ProcessStartInfo(soxPath,
    		string.Format("\"{0}\" -n stat", audioPath));
    	startInfo.UseShellExecute = false;
    	startInfo.CreateNoWindow = true;
    	startInfo.RedirectStandardError = true;
    	startInfo.RedirectStandardOutput = true;
    	var process = Process.Start(startInfo);
    	process.WaitForExit();
    
    	string str;
    	using (var outputThread = process.StandardError)
    		str = outputThread.ReadToEnd();
    
    	if (string.IsNullOrEmpty(str))
    		using (var outputThread = process.StandardOutput)
    			str = outputThread.ReadToEnd();
    
    	try
    	{
    		string[] lines = str.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
    		string lengthLine = lines.First(line => line.Contains("Length (seconds)"));
    		duration = double.Parse(lengthLine.Split(':')[1]);
    	}
    	catch (Exception ex)
    	{
    	}
    
    	return duration;
    }
