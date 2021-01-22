    Process[] procList = Process.GetProcesses();
    for (int i = 0; i <= procList.Length - 1; i ++) {
    	string strProcName = procList[i].ProcessName;
    
    	string strProcTitle = procList[i].MainWindowTitle();
             //check for your process name.. here i m checking excel process
    	if (strProcName.ToLower().Trim().Contains("excel")) {
    		
    		procList[i].Kill();
    	}
    }
