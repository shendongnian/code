    var timeout = AppSettings.GetIntValue(
                Constants.SettingsKeyProcessFinderTimeout, Constants.ProcessFinderTimeoutDefault);
    int elapsedTime = 0;
    Process process = null;
    while (elapsedTime <= timeout)
    {
        process =
            Process.GetProcessesByName("mstsc").FirstOrDefault(p => p.StartInfo.Arguments.Contains(guid));
        Logger.TraceVerbose(
            string.Format(
                "Elapsed time: {0}; Found process with PID {1}", elapsedTime, process == null ? -1 : process.Id));
        if (process != null)
        {
            break;
        }
        Thread.Sleep(SleepInterval);
        elapsedTime += SleepInterval;
    }
