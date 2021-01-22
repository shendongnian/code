    public void CopyFolder(string source, string destination)
    {
    	string xcopyPath = Environment.GetEnvironmentVariable("WINDIR") + @"\System32\xcopy.exe";
    	ProcessStartInfo info = new ProcessStartInfo(xcopyPath);
    	info.UseShellExecute = false;
    	info.RedirectStandardOutput = true;
    	info.Arguments = string.Format("\"{0}\" \"{1}\" /E /I", source, destination);
    
    	Process process = Process.Start(info);
    	process.WaitForExit();
    	string result = process.StandardOutput.ReadToEnd();
    
    	if (process.ExitCode != 0)
    	{
    		// Or your own custom exception, or just return false if you prefer.
    		throw new InvalidOperationException(string.Format("Failed to copy {0} to {1}: {2}", source, destination, result));
    	}
    }
