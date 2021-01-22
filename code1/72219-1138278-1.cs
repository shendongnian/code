    private void Form1_Load(object sender, EventArgs e)
    {
    
    	Process p = new Process();
    	p.StartInfo.FileName = "iexplore.exe";
    	p.StartInfo.Arguments = "about:blank";
    	p.Start();
    
    	Process p2 = new Process();
    	p2.StartInfo.FileName = "iexplore.exe";
    	p2.StartInfo.Arguments = "about:blank";
    	p2.Start();
    
    	if( FindWindow("iexplore.exe", 2) == p2.MainWindowHandle )
    	{
    		MessageBox.Show("OK");
    	}
    
    }
    private IntPtr FindWindow(string title, int index)
    {
    	List<Process> l = new List<Process>();
    
    	Process[] tempProcesses;
    	tempProcesses = Process.GetProcesses();
    	foreach (Process proc in tempProcesses)
    	{
    		if (proc.MainWindowTitle == title)
    		{
    			l.Add(proc);
    		}
    	}
    
    	if (l.Count > index) return l[index].MainWindowHandle;
    	return (IntPtr)0;
    }
