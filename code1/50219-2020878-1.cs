    if (_isRestart)
    {
       try
       {
          // get old process and wait UP TO 5 secs then give up!
          Process oldProcess = Process.GetProcessById(_restartProcessId);
          oldProcess.WaitForExit(5000);
       }
       catch (Exception ex)
       { 
          // the process did not exist - probably already closed!
          //TODO: --> LOG
       }
    }
               
