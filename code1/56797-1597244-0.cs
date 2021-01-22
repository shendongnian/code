    [DllImport("advapi32")]
    static extern bool QueryServiceStatusEx(IntPtr hService, int InfoLevel, ref SERVICE_STATUS_PROCESS lpBuffer, int cbBufSize, out int pcbBytesNeeded);
    const int SC_STATUS_PROCESS_INFO = 0;
    [StructLayout(LayoutKind.Sequential)]
    struct SERVICE_STATUS_PROCESS
    {
      public int dwServiceType;
      public int dwCurrentState;
      public int dwControlsAccepted;
      public int dwWin32ExitCode;
      public int dwServiceSpecificExitCode;
      public int dwCheckPoint;
      public int dwWaitHint;
      public int dwProcessId;
      public int dwServiceFlags;
    }
    const int SERVICE_WIN32_OWN_PROCESS = 0x00000010;
    const int SERVICE_RUNS_IN_SYSTEM_PROCESS = 0x00000001;
    public static void StopServiceAndWaitForExit(string serviceName)
    {
      using (ServiceController controller = new ServiceController(serviceName))
      {
        SERVICE_STATUS_PROCESS ssp = new SERVICE_STATUS_PROCESS();
        int ignored;
        // Obtain information about the service, and specifically its hosting process,
        // from the Service Control Manager.
        if (!QueryServiceStatusEx(controller.ServiceHandle.DangerousGetHandle(), SC_STATUS_PROCESS_INFO, ref ssp, Marshal.SizeOf(ssp), out ignored))
          throw new Exception("Couldn't obtain service process information.");
        // A few quick sanity checks that what the caller wants is *possible*.
        if (ssp.dwServiceType != SERVICE_WIN32_OWN_PROCESS)
          throw new Exception("Can't wait for the service's hosting process to exit because there may be multiple services in the process (dwServiceType is not SERVICE_WIN32_OWN_PROCESS");
        if ((ssp.dwServiceFlags & SERVICE_RUNS_IN_SYSTEM_PROCESS) != 0)
          throw new Exception("Can't wait for the service's hosting process to exit because the hosting process is a critical system process that will not exit (SERVICE_RUNS_IN_SYSTEM_PROCESS flag set)");
        if (ssp.dwProcessId == 0)
          throw new Exception("Can't wait for the service's hosting process to exit because the process ID is not known.");
        // Note: It is possible for the next line to throw an ArgumentException if the
        // Service Control Manager's information is out-of-date (e.g. due to the process
        // having *just* been terminated in Task Manager) and the process does not really
        // exist. This is a race condition. The exception is the desirable result in this
        // case.
        using (Process process = Process.GetProcessById(ssp.dwProcessId))
        {
          // The actual wait, using process.WaitForExit, opens a handle with the SYNCHRONIZE
          // permission only and closes the handle before returning. As long as that handle
          // is open, the process can be monitored for termination, but if the process exits
          // before the handle is opened, it is no longer possible to open a handle to the
          // original process and, worse, though it exists only as a technicality, there is
          // a race condition in that another process could pop up with the same process ID.
          // As such, we definitely want the handle to be opened before we ask the service
          // to close, but since the handle's lifetime is only that of the call to WaitForExit
          // and while WaitForExit is blocking the thread we can't make calls into the SCM,
          // it would appear to be necessary to perform the wait on a separate thread.
          ProcessWaitForExitData threadData = new ProcessWaitForExitData();
          threadData.Process = process;
          Thread processWaitForExitThread = new Thread(ProcessWaitForExitThreadProc);
          processWaitForExitThread.IsBackground = Thread.CurrentThread.IsBackground;
          processWaitForExitThread.Start(threadData);
          // Now we ask the service to exit.
          controller.Stop();
          // Instead of waiting until the *service* is in the "stopped" state, here we
          // wait for its hosting process to go away. Of course, it's really that other
          // thread waiting for the process to go away, and then we wait for the thread
          // to go away.
          lock (threadData.Sync)
            while (!threadData.HasExited)
              Monitor.Wait(threadData.Sync);
        }
      }
    }
    class ProcessWaitForExitData
    {
      public Process Process;
      public volatile bool HasExited;
      public object Sync = new object();
    }
    static void ProcessWaitForExitThreadProc(object state)
    {
      ProcessWaitForExitData threadData = (ProcessWaitForExitData)state;
      try
      {
        threadData.Process.WaitForExit();
      }
      catch {}
      finally
      {
        lock (threadData.Sync)
        {
          threadData.HasExited = true;
          Monitor.PulseAll(threadData.Sync);
        }
      }
    }
