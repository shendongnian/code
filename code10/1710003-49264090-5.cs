    Process _process;
    StreamWriter _inputWriter;
    AsyncStreamReader _output;
    
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
    	
    	Console.WriteLine("Starting...");
    	if (!_process.Start()) return;
    	BeginRead();
    	_inputWriter = _process.StandardInput;
    	_inputWriter.AutoFlush = true;
    	
    	Thread.Sleep(500);
    	
    	string input = Util.ReadLine<string>("Type a command:");
    	if (!string.IsNullOrEmpty(input)) _inputWriter.WriteLine(input);
    	
    	_process.WaitForExit(5000);
    	CancelRead();
    	_process.Kill();
    	Console.WriteLine("Done");
    }
    
    void OnOutput(string data)
    {
    	Console.Write(data);
    }
    
    void BeginRead()
    {
    	if (_output == null) _output = new AsyncStreamReader(_process, _process.StandardOutput.BaseStream, OnOutput, _process.StandardOutput.CurrentEncoding);
    	_output.BeginRead();
    }
    
    void CancelRead()
    {
    	_output.CancelOperation();
    }
