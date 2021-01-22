	string strProcTitle = procList[i].MainWindowTitle();
         //check for your process name.. here i m checking excel process
	if (strProcName.ToLower().Trim().Contains("excel")) {
		
		procList[i].Kill();
	}
}
