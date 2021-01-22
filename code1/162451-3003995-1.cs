    private StreamWriter m_Writer;
    
    public void RunProcess(string filename, string arguments)
    {
    	ProcessStartInfo psi = new ProcessStartInfo();
    	psi.FileName = filename;
    	psi.Arguments = arguments;
    	psi.RedirectStandardInput = true;
    	psi.RedirectStandardOutput = true;
    	psi.UseShellExecute = false;
    
    	Process process = Process.Start(psi);
    	m_Writer = process.StandardInput;
    	process.EnableRaisingEvents = true;
    	process.OutputDataReceived += new DataReceivedEventHandler(OnOutputDataReceived);
    	process.BeginOutputReadLine();
    }
    
    protected void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
    	// Data Received From Application Here
    	// The data is in e.Data
    	// You can prompt the user and write any response to m_Writer to send
    	// The text back to the appication
    }
