    static void Main(string[] args)
    {
    	var startInfo = new ProcessStartInfo
    	{
    		FileName = @"/bin/bash",
    		Arguments = @"-c ""echo hello""",
    		RedirectStandardOutput = true,
    		UseShellExecute = false
    	};
    
    	using (var process = new Process { StartInfo = startInfo })
    	{
    		process.Start();
    		string result = process.StandardOutput.ReadToEnd();
    		process.WaitForExit();
    
    		Console.WriteLine(result);
    
    		Console.Read();
    	}
    }
