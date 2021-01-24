    Process _process;
    StreamWriter _inputWriter;
    
    void Main()
    {
    	_process = new Process
    	{
    		EnableRaisingEvents = true,
    		StartInfo = new ProcessStartInfo
    		{
    			FileName = "cmd.exe",
    			Arguments = string.Empty,
    			UseShellExecute = false,
    			CreateNoWindow = true,
    			WindowStyle = ProcessWindowStyle.Hidden,
    			WorkingDirectory = Directory.GetCurrentDirectory(),
    			StandardOutputEncoding = Encoding.UTF8,
    			StandardErrorEncoding = Encoding.UTF8,
    			RedirectStandardInput = true,
    			RedirectStandardOutput = true,
    			RedirectStandardError = true
    		}
    	};
    
    	_process.OutputDataReceived += (s, e) => // instead of using a background worker
    	{
    		if (e.Data == null) return;
    		Console.WriteLine(e.Data);
    	};
    	
    	Console.WriteLine("Starting...");
    	if (!_process.Start()) return;
    	_process.BeginOutputReadLine(); // <- using BeginOutputReadLine
    	_inputWriter = _process.StandardInput;
    	_inputWriter.AutoFlush = true;
    	_inputWriter.WriteLine(); // <- my little trick here
    	
    	string input = Util.ReadLine<string> ("Enter command:"); // using LINQPad, replace it with Console.ReadLine();
    	if (!string.IsNullOrEmpty(input)) _inputWriter.WriteLine(input);
    	_process.WaitForExit(5000);
    	_process.Kill();
    	Console.WriteLine("Done");
    }
    
    void OnOutput(string data)
    {
    	Console.WriteLine(data);
    }
