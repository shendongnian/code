    public void KickOffProcess(string filePath) {
      var proc = Process.Start(filePath);
      ThreadPool.QueueUserWorkItem(new WaitCallBack(WaitForProc), proc);
    }
    
    private void WaitForProc(object obj) {
      var proc = (Process)obj;
      proc.WaitForExit();
      // Do the file deletion here
    }
